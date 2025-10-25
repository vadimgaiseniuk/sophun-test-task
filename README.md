# Unity Developer Test Task - Leaderboard Popup

## Architecture

The game architecture is based on a finite state machine (FSM), which provides a clean and maintainable way to control the game’s flow and states.
Each scripts folder contains its own .asmdef file to ensure clear dependency management and modular code separation:

- Architecture — contains the core logic of the game’s architecture.

- Services — includes the main independent services used throughout the game.

- App — holds functionality and visual elements that appear on screen, such as the User Interface or Global State Machine.

## Composition Root

Zenject is used for dependency injection.
All services and the Global State Machine are bound within the Global Installer.
The game is launched through a Bootstrapper, which initializes the BootstrapState.

## Services

Each independent functionality is encapsulated within its own service to maintain separation of concerns and adhere to the Single Responsibility Principle.
The Popup Service was renamed to match the project’s naming conventions and underwent minor functional adjustments.

## User Interface Architecture

To avoid major refactoring of the existing Popup Service, I adapted it to follow the MVP (Model–View–Presenter) pattern.
In this approach:

- The Model is represented by the Global State Machine’s state.

- The View contains only references to UI objects.

- The Presenter handles the construction and population of dynamic child UI elements.

## Changes to the Original Code

In the original implementation, the object param argument used in the PopupService was, in my opinion, an unacceptable solution.
It not only lacked type safety but also introduced unnecessary overhead through boxing/unboxing when casting to concrete types.

To address this, I replaced it with a generic type parameter that specifies the data passed to the popup.
The model is also passed as a generic parameter, allowing the service to be easily reused across different states and popups.

However, this approach has one limitation:
if the generic types are not explicitly specified in the calling method, the compiler will not produce an error, and the method will simply not be called — which can be difficult to debug if not known.
While this implementation works, it is not ideal and could be refactored for improved type safety.
(I chose not to refactor further to avoid introducing large-scale changes to the original code.)

## Remarks

One of the requirements stated that player avatars should load after the popup appears.
In the original PopupService, the popup was disabled before initialization and enabled afterward.
To meet this requirement, I removed the disabling step so that avatars could be loaded dynamically after the popup becomes visible.
This was done to maintain clean separation — since storing the popup instance in the model or adding another “post-initialization” method would have been an inelegant solution.

Additionally, the Asset Managing Service is currently used in multiple UI-related places.
Ideally, UI creation should be delegated to a dedicated factory or mediator, responsible for constructing all UI objects for the scene.
However, I chose not to implement this change due to time constraints and to avoid adding unnecessary complexity to the existing codebase.
