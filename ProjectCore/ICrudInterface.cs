using ProjectCore.Models.Responses;

namespace ProjectCore
{
    public interface ICrudInterface
    {
        Task<GlobalGetResponse> GetOne(int id);

        Task<GlobalGetResponse> GetAll();

        Task<GlobalPostResponse> Create(object model);

        Task<GlobalPostResponse> Edit(object model);

        Task<GlobalGetResponse> Delete(int id);
    }
}
