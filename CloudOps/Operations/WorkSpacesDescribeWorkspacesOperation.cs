using Amazon;
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class WorkSpacesDescribeWorkspacesOperation : Operation
    {
        public override string Name => "DescribeWorkspaces";

        public override string Description => "Describes the specified WorkSpaces. You can filter the results by using the bundle identifier, directory identifier, or owner, but you can specify only one filter at a time.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "WorkSpaces";

        public override string ServiceID => "WorkSpaces";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonWorkSpacesClient client = new AmazonWorkSpacesClient(creds, region);
            DescribeWorkspacesResult resp = new DescribeWorkspacesResult();
            do
            {
                DescribeWorkspacesRequest req = new DescribeWorkspacesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.DescribeWorkspaces(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Workspaces)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}