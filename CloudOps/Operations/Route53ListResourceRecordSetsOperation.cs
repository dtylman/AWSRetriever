using Amazon;
using Amazon.Route53;
using Amazon.Route53.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class Route53ListResourceRecordSetsOperation : Operation
    {
        public override string Name => "ListResourceRecordSets";

        public override string Description => "Lists the resource record sets in a specified hosted zone.  ListResourceRecordSets returns up to 100 resource record sets at a time in ASCII order, beginning at a position specified by the name and type elements.  Sort order   ListResourceRecordSets sorts results first by DNS name with the labels reversed, for example:  com.example.www.  Note the trailing dot, which can change the sort order when the record name contains characters that appear before . (decimal 46) in the ASCII table. These characters include the following: ! &#34; # $ % &amp;amp; &#39; ( ) * &#43; , -  When multiple records have the same DNS name, ListResourceRecordSets sorts results by the record type.  Specifying where to start listing records  You can use the name and type elements to specify the resource record set that the list begins with:  If you do not specify Name or Type  The results begin with the first resource record set that the hosted zone contains.  If you specify Name but not Type  The results begin with the first resource record set in the list whose name is greater than or equal to Name.  If you specify Type but not Name  Amazon Route 53 returns the InvalidInput error.  If you specify both Name and Type  The results begin with the first resource record set in the list whose name is greater than or equal to Name, and whose type is greater than or equal to Type.    Resource record sets that are PENDING  This action returns the most current version of the records. This includes records that are PENDING, and that are not yet available on all Route 53 DNS servers.  Changing resource record sets  To ensure that you get an accurate listing of the resource record sets for a hosted zone at a point in time, do not submit a ChangeResourceRecordSets request while you&#39;re paging through the results of a ListResourceRecordSets request. If you do, some pages may display results without the latest changes while other pages display results with the latest changes.  Displaying the next page of results  If a ListResourceRecordSets command returns more than one page of results, the value of IsTruncated is true. To display the next page of results, get the values of NextRecordName, NextRecordType, and NextRecordIdentifier (if any) from the response. Then submit another ListResourceRecordSets request, and specify those values for StartRecordName, StartRecordType, and StartRecordIdentifier.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "Route53";

        public override string ServiceID => "Route 53";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRoute53Client client = new AmazonRoute53Client(creds, region);
            Response resp = new Response();
            do
            {
                ListResourceRecordSetsRequest req = new ListResourceRecordSetsRequest
                {
                    StartRecordNameStartRecordTypeStartRecordIdentifier = resp.NextRecordNameNextRecordTypeNextRecordIdentifier
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListResourceRecordSets(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ResourceRecordSets)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextRecordNameNextRecordTypeNextRecordIdentifier));
        }
    }
}