# Rocket Boost

A physics-based arcade game built in **Unity**, where the player controls a rocket and navigates through obstacles to reach the goal.

This project started as a tutorial-based implementation and was later **refactored to improve gameplay architecture, robustness, and clarity**, serving as a hands-on case study in gameplay systems design.

---

## 🎮 Gameplay Overview
- Control a rocket using thrust and rotation
- Avoid obstacles and hazards
- Reach the finish platform to complete levels
- Crash and success states with delayed transitions

---

## 🧠 Case Study: Refactoring Rocket Boost

### Initial Problems
While the game was functional, the initial implementation had several issues:
- Input, movement, audio, VFX, and collision logic tightly coupled
- Collision events triggering multiple times
- Player still controllable after crash or success
- Audio cutting off during scene transitions
- Physics behaving inconsistently after collisions

---

### Refactor Highlights
- Separated gameplay responsibilities into dedicated components:
  - Input handling
  - Player movement & rotation
  - Audio and VFX feedback
  - Collision handling
- Introduced a **player state system** (`Alive`, `Dead`, `Transitioning`) to prevent duplicate triggers
- Disabled input, movement, and colliders immediately on collision
- Differentiated crash vs success physics behavior for better game feel
- Used **coroutines** to synchronize scene transitions with audio playback
- Improved overall readability, maintainability, and extensibility of gameplay code

---

## 🧠 What I Learned
- Designing simple state-driven gameplay systems
- Managing physics, input, and collisions in Unity
- Debugging timing-related issues using breakpoints and logs
- Structuring Unity projects beyond tutorial-style scripts
- Applying software engineering principles to gameplay programming

---

## 🛠 Tech Stack
- Unity
- C#

---

## 📌 Project Status
✅ **Refactor complete**

This project now serves as a **gameplay architecture case study** in my portfolio.

---

## 🚀 Possible Future Improvements
- Data-driven configuration using ScriptableObjects
- Event-based communication between gameplay systems
- Additional gameplay polish (camera effects, feedback tuning)
