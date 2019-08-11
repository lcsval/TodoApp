using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Shared.Commands
{
    public interface ICommand {

        bool Valid();
    }
}
