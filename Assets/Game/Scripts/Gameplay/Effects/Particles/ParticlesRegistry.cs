using System;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Effects
{
    public class ParticlesRegistry : MonoBehaviour
    {
        [ValidateInput(nameof(IsUniqueParticleLink))]
        [SerializeField] private ParticleLink[] _links;
        
        public bool IsExistsParticlesPool(ParticleType type, out ParticlesPoolBehaviour pool)
        {
            pool = _links.Where(x => x.Type == type).Select(x => x.Pool).FirstOrDefault();
        
            return pool != null;
        }

        private bool IsUniqueParticleLink(ParticleLink[] links, ref string errorMessage)
        {
            if (links.GroupBy(x => x.Type).Count() != links.Length)
            {
                errorMessage = "Particle types must be unique";
                
                return false;
            }
            
            return true;
        }
        
        [Serializable]
        public class ParticleLink
        {
            [SerializeField] private ParticleType _type;
            
            [ChildGameObjectsOnly, Required]
            [SerializeField] private ParticlesPoolBehaviour _pool;

            public ParticleType Type => _type;

            public ParticlesPoolBehaviour Pool => _pool;
        }
    }
}