namespace onfleet
{
    public class ofOrganizationService : ofService
    {
        public ofOrganizationService(string apiKey = null) : base(apiKey) { }

        public virtual ofOrganization Get(ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var org = Requestor.Get<ofOrganization>(Urls.Organization, requestOptions);
            return org;
        }

        public ofOrganization GetDelegatee(string delegateeId, ofRequestOptions requestOptions)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var org = Requestor.Get<ofOrganization>(string.Format("{0}/{1}", Urls.Organizations, delegateeId), requestOptions);
            return org;
        }
    }
}
