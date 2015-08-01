using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class TargetAudienceList : IEnumerable<TargetAudience>
    {
        private List<TargetAudience> TargetAudiences { get; set; }

        public TargetAudienceList(string json)
        {
            TargetAudience targetAudience;
            TargetAudiences = new List<TargetAudience>();

            JObject jObject = JObject.Parse(json);
            JToken jTargertAudienceList = jObject["data"];

            foreach (JToken token in jTargertAudienceList)
            {
                targetAudience = new TargetAudience();
                targetAudience.ID = (string)token["id"];
                targetAudience.Name = (string)token["name"];

                TargetAudiences.Add(targetAudience);
            }
        }

        public IEnumerator<TargetAudience> GetEnumerator()
        {
            return TargetAudiences.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
