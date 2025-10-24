# Unity Developer Test Task - Leaderboard Popup

## Architecture

- For game's architecture i used a finite state machine, which allows to easily control it's state and do it clean.
- Each scripts folder contains it's own .asmdef file for better dependency management and code separation 
  (Architecture - contains the base code for the game's architecture, Services - conttains main services that are used in the game, App - contains functionality and code which we actually see on the screen, e.g. User Interface or Global State Machine)

## Composition Root

- Zenject is used for dependency injection
- All services and Global State Machine are binded in the Global Installer

## Services

- Each independant functionality was moved to a separate service so we don't have mixed responsibilities and complete the Single Responsibility principle
- Popup Service was renamed to fit project's naming conventions and had some minor functionality changes

### User Interface Acrhitecture

- To not drastically change the existing Popup Service i adapted it to use MVP pattern,
  where we have our Global State Machine's state as the model, the view which only contains references to the UI objects and a presenter which handles the construction and populattion of child ui objects

### Changes to original code
 - In Popup Service "object param" parameter was an unacceptable sollution in my opinion, not only does it not limit the code in any way but also produces unneccessary overhead by needing to box/unbox the object while casting it to the concrete implementation.
   For the data which is passed to the popup i used generic type which is specified in the model which is calling the OpenPopup() method, the model is also passed as a generic parameter which allows to easily reuse the service in multiple states with differrent popups, 
   however there is one thing which is problematic - if the generics are not specified in the calling method, there will be no compiler error and the method will not be called at all which is hard to debug if this is not known, so this implementation is not the best one and could be refactored to a better state(i will not do that as it will produce many changes to the original code) 

### Remarks
- One of the requirements said that the player avatars should be loaded after the popup appeared: in the original PopupService implementation the popup is disabled before initialization and enabled right after it's finished, however for this requirement to be completed i decided to remove the disabling of the popup before initialization as there is no clean way to perform the loading of avatars afterwards, since we should not store the popup instance in the model and introducing another method just to do the loading after we initialized the popup is not a clean sollution.
- Also the User Interface is created by using Asset Managing Service in multiple placec which is not really good and should be moved to a separate entity like factory or mediator which would be responsible for creating all the UI objects needed for the scene. I chose not to do that to avoid adding unnecessary complexity to the code and because of time constraints.