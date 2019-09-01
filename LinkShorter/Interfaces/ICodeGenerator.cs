using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkShorter.Interfaces {
    public interface ICodeGenrator {
        string GetUniqueRandomCode();
    }
}
