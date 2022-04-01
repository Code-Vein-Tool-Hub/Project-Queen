using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QueenIO;

namespace Project_Queen.IO
{
    public class Common
    {
        public static bool VerifyFile(Relic relic, string Type)
        {
            int import = relic.Exports[relic.Exports.FindIndex(x => x.ObjectName.Value.Value == Path.GetFileNameWithoutExtension(relic.FilePath))].TemplateIndex.Index;
            string template = relic.Imports[(import *= -1) - 1].ClassName.Value.Value;
            return template.Equals(Type);
        }
    }
}
