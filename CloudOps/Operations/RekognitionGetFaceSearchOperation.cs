using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RekognitionGetFaceSearchOperation : Operation
    {
        public override string Name => "GetFaceSearch";

        public override string Description => "Gets the face search results for Amazon Rekognition Video face search started by . The search returns faces in a collection that match the faces of persons detected in a video. It also includes the time(s) that faces are matched in the video. Face search in a video is an asynchronous operation. You start face search by calling to which returns a job identifier (JobId). When the search operation finishes, Amazon Rekognition Video publishes a completion status to the Amazon Simple Notification Service topic registered in the initial call to StartFaceSearch. To get the search results, first check that the status value published to the Amazon SNS topic is SUCCEEDED. If so, call GetFaceSearch and pass the job identifier (JobId) from the initial call to StartFaceSearch. For more information, see Searching Faces in a Collection in the Amazon Rekognition Developer Guide. The search results are retured in an array, Persons, of objects. EachPersonMatch element contains details about the matching faces in the input collection, person information (facial attributes, bounding boxes, and person identifer) for the matched person, and the time the person was matched in the video.   GetFaceSearch only returns the default facial attributes (BoundingBox, Confidence, Landmarks, Pose, and Quality). The other facial attributes listed in the Face object of the following response syntax are not returned. For more information, see FaceDetail in the Amazon Rekognition Developer Guide.   By default, the Persons array is sorted by the time, in milliseconds from the start of the video, persons are matched. You can also sort by persons by specifying INDEX for the SORTBY input parameter.";
 
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
                GetFaceSearchRequest req = new GetFaceSearchRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetFaceSearch(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}