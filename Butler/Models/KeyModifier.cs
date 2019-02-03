using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butler.Models
{
    public enum KeyModifier
    {
        None = 0,
        Ctrl = 1,
        Alt = 2,
        Shift = 4,
        AltShift = Alt + Shift,
        CtrlAlt = Ctrl + Alt,
        CtrlShift = Ctrl + Shift,
        CtrlAltShift = Ctrl + Alt + Shift
    }
}
