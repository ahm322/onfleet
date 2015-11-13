using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onfleet
{
    public class ofOrgnizationService : ofService
    {
        public ofOrgnizationService(string apiKey = null) : base(apiKey) { }

        public virtual ofOrganization Get(ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var org = Requestor.Get<ofOrganization>(Urls.Organization, requestOptions);
            return org;
        }
    }
}
