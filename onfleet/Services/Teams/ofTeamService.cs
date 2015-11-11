using System;
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

    }
}
