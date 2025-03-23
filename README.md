# Base Warriors [Unity DOTS]

A sample game in the style of base warriors using Unity DOTS.

The game is played by two players. Each player has their own base and army. Players can create their armies.  
The armies automatically fight each other on the map. The goal of the game is to destroy the enemy's base.

![============ GIF DEMONSTRATION ============](images/demo.gif)

### Dependencies:

- Entities 1.3.9  
- Entities Graphics 1.3.2  
- Unity Physics 1.3.9  
- Rukhanka Animation System 2.0.0 (paid)

### Description of Some Architectural Principles of the Project

1. **Signal Dispatching Principle**  

   Systems can communicate with each other via signals.  
   For example, if a new unit needs to be created, a signal is generated with a request to instantiate the unit on the scene.  
   The key principle is that only one system should handle a signal, and this system must delete the signal after processing it.  

   Signals are implemented using `IBufferElementData` and `IEnableableComponent`.  
   - In the case of a buffer, the receiving system always clears the buffer after processing.  
   - In the case of an `IEnableableComponent`, the signal is disabled after it has been processed.  

2. **Event Dispatching Principle**  

   Events are generated to be processed by presentation systems. These events can be processed by multiple systems within the same execution cycle of all systems.  

   For instance, if a unit takes damage, a damage-received event is generated. Presentation systems, such as animation, sound, or damage particle systems, can respond to this event.  

   At the very end of the cycle, a special system cleans up all events.  

**What Could Be Improved in the Current Project:**

- Create a separate world dedicated to requests and events.  
- Remove the animator from core mechanics.  
- Further offload systems by moving some code to UseCases.  
- Remove methods and getters from aspects, transferring them into UseCases.  
- Avoid using aspects and move query conditions directly into systems to improve code readability.  
