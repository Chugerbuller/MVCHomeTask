using mvc.Controllers;
using mvc.DI;

var controller = new TaskController(DiContainer.GetView(ViewTypes.Task)!);
controller.Run();