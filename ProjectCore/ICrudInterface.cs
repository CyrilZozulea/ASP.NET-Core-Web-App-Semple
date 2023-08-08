using ProjectCore.Models.Responses;

namespace ProjectCore
{
    public interface ICrudInterface
    {
        public abstract Task<GlobalGetResponse> GetOne(int id);

        public abstract Task<GlobalGetResponse> GetAll();

        public abstract Task<GlobalPostResponse> Create(object model);

        public abstract Task<GlobalPostResponse> Edit(object model);

        public abstract Task<GlobalGetResponse> Delete(int id);
    }
}
