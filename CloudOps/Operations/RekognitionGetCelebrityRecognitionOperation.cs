using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RekognitionGetCelebrityRecognitionOperation : Operation
    {
        public override string Name => "GetCelebrityRecognition";

        public override string Description => "Gets the celebrity recognition results for a Amazon Rekognition Video analysis started by . Celebrity recognition in a video is an asynchronous operation. Analysis is started by a call to which returns a job identifier (JobId). When the celebrity recognition operation finishes, Amazon Rekognition Video publishes a completion status to the Amazon Simple Notification Service topic registered in the initial call to StartCelebrityRecognition. To get the results of the celebrity recognition analysis, first check that the status value published to the Amazon SNS topic is SUCCEEDED. If so, call GetCelebrityDetection and pass the job identifier (JobId) from the initial call to StartCelebrityDetection.  For more information, see Working With Stored Videos in the Amazon Rekognition Developer Guide.  GetCelebrityRecognition returns detected celebrities and the time(s) they are detected in an array (Celebrities) of objects. Each CelebrityRecognition contains information about the celebrity in a object and the time, Timestamp, the celebrity was detected.    GetCelebrityRecognition only returns the default facial attributes (BoundingBox, Confidence, Landmarks, Pose, and Quality). The other facial attributes listed in the Face object of the following response syntax are not returned. For more information, see FaceDetail in the Amazon Rekognition Developer Guide.   By default, the Celebrities array is sorted by time (milliseconds from the start of the video). You can also sort the array by celebrity by specifying the value ID in the SortBy input parameter. The CelebrityDetail object includes the celebrity identifer and additional information urls. If you don&#39;t store the additional information urls, you can get them later by calling with the celebrity identifer. No information is returned for faces not recognized as celebrities. Use MaxResults parameter to limit the number of labels returned. If there are more results than specified in MaxResults, the value of NextToken in the operation response contains a pagination token for getting the next set of results. To get the next page of results, call GetCelebrityDetection and populate the NextToken request parameter with the token value returned from the previous call to GetCelebrityRecognition.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "Rekognition";

        public override string ServiceID => "Rekognition";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRekognitionClient client = new AmazonRekognitionClient(creds, region);
            Response resp = new Response();
            do
            {
                GetCelebrityRecognitionRequest req = new GetCelebrityRecognitionRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetCelebrityRecognition(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}