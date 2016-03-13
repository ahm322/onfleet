using System.Collections.Generic;

namespace onfleet
{
    public class ofTeamService : ofService
    {
        public ofTeamService(string apiKey = null) : base(apiKey) { }

        public virtual IEnumerable<ofTeam> List(ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);
            var response = Requestor.Get<List<ofTeam>>(Urls.Teams, requestOptions);

            return response;
        }

        public virtual ofTeam Get(string id, ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            return Requestor.Get<ofTeam>(string.Format("{0}/{1}", Urls.Teams, id), requestOptions);
        }
    }
}
