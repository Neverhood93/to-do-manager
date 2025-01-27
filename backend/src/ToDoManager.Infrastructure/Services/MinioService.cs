using Minio;
using Minio.DataModel.Args;
using ToDoManager.Application.Services;
using Microsoft.Extensions.Configuration;

namespace ToDoManager.Infrastructure.Services;

public class MinioService : IFileService
{
    private readonly IMinioClient _minioClient;
    private readonly string _bucketName;

    public MinioService(IConfiguration config)
    {
        _minioClient = new MinioClient()
            .WithEndpoint(config["MinIO:Endpoint"])
            .WithCredentials(config["MinIO:AccessKey"], config["MinIO:SecretKey"])
            .WithSSL(false)
            .Build();

        _bucketName = config["MinIO:BucketName"] ?? throw new ArgumentNullException(nameof(_bucketName));

        //_minioClient = new MinioClient()
        //    .WithEndpoint("http://minio:9000")
        //    .WithCredentials("minioadmin", "minioadmin")
        //    .WithSSL(false)
        //    .Build();

        //_bucketName = "uploads";
    }

    private async Task EnsureBucketExistsAsync()
    {
        var args = new BucketExistsArgs().WithBucket(_bucketName);
        bool found = await _minioClient.BucketExistsAsync(args);

        if (!found)
        {
            var makeBucketArgs = new MakeBucketArgs().WithBucket(_bucketName);
            await _minioClient.MakeBucketAsync(makeBucketArgs);
        }
    }

    public async Task UploadFileAsync(string fileName, Stream fileStream)
    {
        await EnsureBucketExistsAsync();

        var args = new PutObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(fileName)
            .WithStreamData(fileStream)
            .WithObjectSize(fileStream.Length)
            .WithContentType("application/octet-stream");

        await _minioClient.PutObjectAsync(args);
    }

    public async Task<Stream> DownloadFileAsync(string fileName)
    {
        var stream = new MemoryStream();

        var args = new GetObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(fileName)
            .WithCallbackStream(async (dataStream) =>
            {
                await dataStream.CopyToAsync(stream);
                stream.Position = 0;
            });

        await _minioClient.GetObjectAsync(args);

        return stream;
    }

    public async Task DeleteFileAsync(string fileName)
    {
        var args = new RemoveObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(fileName);

        await _minioClient.RemoveObjectAsync(args);
    }
}
