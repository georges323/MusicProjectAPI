using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class FileService : IFileService
{
    private readonly string? AWS_ACCESS_KEY;
    private readonly string? AWS_SECRET_KEY;
    private readonly string? AWS_BUCKET_NAME;
    private readonly string? AWS_REGION;

    private static IAmazonS3 _s3Client;

    public FileService(IConfiguration configuration)
    {     
        AWS_ACCESS_KEY = configuration?.GetSection("AWS")["AccessKey"];
        AWS_SECRET_KEY = configuration?.GetSection("AWS")["SecretKey"];
        AWS_BUCKET_NAME = configuration?.GetSection("AWS")["BucketName"];
        AWS_REGION = configuration?.GetSection("AWS")["Region"];

        var credentials = new BasicAWSCredentials(AWS_ACCESS_KEY, AWS_SECRET_KEY);
        var config = new AmazonS3Config
        {
            RegionEndpoint = RegionEndpoint.GetBySystemName(AWS_REGION)
        };

        _s3Client = new AmazonS3Client(credentials, config);
    }

    public async Task UploadFile(IFormFile file)
    {
        try
        {
            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = file.OpenReadStream(),
                Key = file.FileName,
                BucketName = AWS_BUCKET_NAME
            };

            var fileTransferUtility = new TransferUtility(_s3Client);
            await fileTransferUtility.UploadAsync(uploadRequest);
        }
        catch (AmazonS3Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Dictionary<string, string> GetFilesUrls(List<string> objectKeys, double duration)
    {
        Dictionary<string, string> objectKeysToUrl = new();

        foreach (var objectKey in objectKeys)
        {
            GetPreSignedUrlRequest getRequest = new GetPreSignedUrlRequest
            {
                BucketName = AWS_BUCKET_NAME,
                Key = objectKey,
                Expires = DateTime.UtcNow.AddHours(duration)
            };

            string urlString;

            try
            {
                urlString = _s3Client.GetPreSignedURL(getRequest);
            }
            catch (AmazonS3Exception e)
            {
                throw new Exception(e.Message);
            }

            objectKeysToUrl.Add(objectKey, urlString);
        }

        return objectKeysToUrl;
    }
}