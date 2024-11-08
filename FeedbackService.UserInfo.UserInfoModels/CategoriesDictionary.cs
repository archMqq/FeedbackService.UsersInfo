using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.UserInfoModels
{
    public class CategoriesDictionary : Dictionary <string, float>
    {
        public CategoriesDictionary():base() { }
        public CategoriesDictionary(IDictionary<string, float> dictionary) : base(dictionary) { }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
