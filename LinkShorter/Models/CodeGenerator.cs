using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkShorter.Interfaces;

namespace LinkShorter.Models {
    public class CodeGenerator :ICodeGenrator{
        const string MASK = "";
        const int RANGE_BEGIN = 65;
        const int RANGE_END = 90;
        public int Lenth { get; set; } = 6;
        private IList<ShortLink> links;
        public CodeGenerator(IList<ShortLink> existLinks) {
            links = existLinks; 
        }

        public string GetUniqueRandomCode() {
            string code = GetRandomCode(); 
            IEnumerator<ShortLink> enumerator = links.GetEnumerator();
            while (enumerator.MoveNext()) {
                if (enumerator.Current.ShortUrl.Equals(code)) {
                    enumerator.Reset();
                    code = GetRandomCode();
                }
            }
            return GetRandomCode();
        }
        public string GetRandomCode() {
            Random random = new Random();
            string code = string.Empty; 
            for(int i = 0;i< Lenth; i++) {
                code+=((char)random.Next(RANGE_BEGIN,RANGE_END));
            }
            return code;
        }
    }
}
