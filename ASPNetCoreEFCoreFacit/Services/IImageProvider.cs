using System;

namespace ASPNetCoreEFCoreFacit.Services
{
    public interface IImageProvider
    {
        string GetBildSource(int itemId, DateTime lastModified);
        string GetSavingPathFor(int id, string uploadedFileName);
        void RemoveExistingImages(int itemId);
    }
}