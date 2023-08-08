using ApplicationBLL.Database.Contexts;
using ApplicationBLL.Models;
using ProjectCore;
using ProjectCore.Models.Responses;

namespace ApplicationBLL.Database
{
    public class BlazorDatabase : ICrudInterface
    {
        private BlazorContext DBContext = new BlazorContext();

        public Task<GlobalPostResponse> Create(object model)
        {
            try
            {
                DBContext.Table.Add((BlazorModel)model);
                DBContext.SaveChanges();

                return Task.Run(() => new GlobalPostResponse
                {
                    ErrorCode = EnErrorCode.OK
                });
            }
            catch (Exception ex)
            {
                return Task.Run(() => new GlobalPostResponse
                {
                    ErrorCode = EnErrorCode.IternalError,
                    ErrorMessage = ex.ToString(),
                });
            }
        }

        public Task<GlobalGetResponse> Delete(int id)
        {
            try
            {
                BlazorModel? model = DBContext.Table.FirstOrDefault(m => m.ID == id);

                if (model != null)
                {
                    DBContext.Table.Remove(model);
                    DBContext.SaveChanges();

                    return Task.Run(() => new GlobalGetResponse
                    {
                        ErrorCode = EnErrorCode.OK
                    });
                }
                else
                {
                    return Task.Run(() => new GlobalGetResponse
                    {
                        ErrorCode = EnErrorCode.NotExist,
                        ErrorMessage = "Not exist"
                    });
                }
            }
            catch (Exception ex)
            {
                return Task.Run(() => new GlobalGetResponse
                {
                    ErrorCode = EnErrorCode.IternalError,
                    ErrorMessage = ex.ToString(),
                });
            }
        }

        public Task<GlobalPostResponse> Edit(object model)
        {
            try
            {
                BlazorModel obj = (BlazorModel)model;
                BlazorModel? exist = DBContext.Table.FirstOrDefault(m => m.ID == obj.ID);

                if (exist != null)
                {
                    exist.Name = obj.Name;
                    exist.Type = obj.Type;
                    exist.Description = obj.Description;

                    DBContext.SaveChanges();

                    return Task.Run(() => new GlobalPostResponse
                    {
                        ErrorCode = EnErrorCode.OK
                    });
                }
                else
                {
                    return Task.Run(() => new GlobalPostResponse
                    {
                        ErrorCode = EnErrorCode.NotExist,
                        ErrorMessage = "Not exist"
                    });
                }
            }
            catch (Exception ex)
            {
                return Task.Run(() => new GlobalPostResponse
                {
                    ErrorCode = EnErrorCode.IternalError,
                    ErrorMessage = ex.ToString(),
                });
            }
        }

        public Task<GlobalGetResponse> GetAll()
        {
            try
            {
                List<BlazorModel> jQueryList = DBContext.Table.ToList();

                if (jQueryList.Count == 0)
                {
                    return Task.Run(() => new GlobalGetResponse
                    {
                        ErrorCode = EnErrorCode.NotExist,
                        ErrorMessage = "Not exist",
                        ResponseObject = jQueryList
                    });
                }
                else
                {
                    return Task.Run(() => new GlobalGetResponse
                    {
                        ErrorCode = EnErrorCode.OK,
                        ResponseObject = jQueryList
                    });
                }
            }
            catch (Exception ex)
            {
                return Task.Run(() => new GlobalGetResponse
                {
                    ErrorCode = EnErrorCode.IternalError,
                    ErrorMessage = ex.ToString(),
                });
            }
        }

        public Task<GlobalGetResponse> GetOne(int id)
        {
            try
            {
                var modal = DBContext.Table.FirstOrDefault(x => x.ID == id);

                if (modal != null)
                {
                    return Task.Run(() => new GlobalGetResponse
                    {
                        ErrorCode = EnErrorCode.OK,
                        ResponseObject = modal
                    });
                }
                else
                {
                    return Task.Run(() => new GlobalGetResponse
                    {
                        ErrorCode = EnErrorCode.NotExist,
                        ErrorMessage = "Not exist"
                    });
                }
            }
            catch (Exception ex)
            {
                return Task.Run(() => new GlobalGetResponse
                {
                    ErrorCode = EnErrorCode.IternalError,
                    ErrorMessage = ex.ToString(),
                });
            }
        }
    }
}
