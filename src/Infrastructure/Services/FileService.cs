using Amazon.Runtime;
using Amazon.S3.Transfer;
using Amazon.S3;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Amazon;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class FileService : IFileService
{
    private readonly string? AWS_ACCESS_KEY;
    private readonly string? AWS_SECRET_KEY;
    private readonly string? BUCKET_NAME;

    public FileService(IConfiguration configuration)
    {     
        AWS_ACCESS_KEY = configuration?.GetSection("AWS")["AccessKey"];
        AWS_SECRET_KEY = configuration?.GetSection("AWS")["SecretKey"];
        BUCKET_NAME = configuration?.GetSection("AWS")["BucketName"];
    }

    public async Task UploadFile(IFormFile file)
    {
        var credentials = new BasicAWSCredentials(AWS_ACCESS_KEY, AWS_SECRET_KEY);
        var config = new AmazonS3Config
        {
            RegionEndpoint = RegionEndpoint.USWest2
        };
        using var client = new AmazonS3Client(credentials, config);

        var uploadRequest = new TransferUtilityUploadRequest
        {
            InputStream = file.OpenReadStream(),
            Key = file.FileName,
            BucketName = BUCKET_NAME
        };

        var fileTransferUtility = new TransferUtility(client);
        await fileTransferUtility.UploadAsync(uploadRequest);
    }
}