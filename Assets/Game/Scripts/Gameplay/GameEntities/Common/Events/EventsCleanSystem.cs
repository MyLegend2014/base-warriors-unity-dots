using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.Collections;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    [UpdateInGroup(typeof(PresentationSystemGroup), OrderLast = true)]
    public partial class EventsCleanSystem : SystemBase
    {
        private IEnumerable<MethodInfo> _eventCleanMethods;

        protected override void OnCreate()
        {
            List<Type> eventTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.IsValueType && typeof(IEvent).IsAssignableFrom(type))
                .ToList();

            List<MethodInfo> eventCleanMethods = new();
            
            foreach (var eventType in eventTypes)
            {
                MethodInfo method = GetType().GetMethod(nameof(DisableEvent), 
                    BindingFlags.NonPublic | BindingFlags.Instance);
                
                MethodInfo genericMethod = method.MakeGenericMethod(eventType);
                eventCleanMethods.Add(genericMethod);
            }
            
            _eventCleanMethods = eventCleanMethods;
        }

        protected override void OnUpdate()
        {
            foreach (MethodInfo eventCleanMethod in _eventCleanMethods)
                eventCleanMethod.Invoke(this, new object[] {});
        }

        private void DisableEvent<TComponent>() 
            where TComponent : IEnableableComponent, IComponentData
        {
            EntityQuery query = new EntityQueryBuilder(Allocator.Temp)
                .WithAll<TComponent>().Build(EntityManager);
            
            if (query.CalculateEntityCount() == 0)
                return;
            
            NativeArray<Entity> entityArray = query.ToEntityArray(Allocator.Temp);

            foreach (Entity entity in entityArray)
                EntityManager.SetComponentEnabled<TComponent>(entity, false);
        }
    }
}