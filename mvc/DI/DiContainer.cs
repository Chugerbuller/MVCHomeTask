using mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.DI;

public enum ViewTypes
{
    Task
}

public class DiContainer
{
    public IView View => new TaskView();

    public static IView? GetView(ViewTypes viewType)
    {
        return viewType switch
        {
            ViewTypes.Task => new TaskView(),
            _ => null
        };
    }
}