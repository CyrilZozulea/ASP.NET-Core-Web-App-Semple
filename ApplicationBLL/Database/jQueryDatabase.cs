using ApplicationBLL.Database.Contexts;
using ApplicationBLL.Models;
using ProjectCore;
using ProjectCore.Models.Responses;

namespace ApplicationBLL.Database
{
    public class jQueryDatabase : ICrudInterface
    {
        private jQueryContext DBContext = new jQueryContext();

        public Task<GlobalPostResponse> Create(object model)
        {
            try
            {
                DBContext.Table.Add((jQueryModel)model);
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
                jQueryModel? model = DBContext.Table.FirstOrDefault(m => m.ID == id);

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
            catch(Exception ex)
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
                jQueryModel obj = (jQueryModel)model;
                jQueryModel? exist = DBContext.Table.FirstOrDefault(m => m.ID == obj.ID);

                if (exist != null)
                {
                    exist.Name = obj.Name;
                    exist.Email = obj.Email;
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
                List<jQueryModel> jQueryList = DBContext.Table.ToList();

                if (jQueryList.Count == 0)
                {
                    return Task.Run(() => new GlobalGetResponse
                    {
                        ErrorCode = EnErrorCode.NotExist,
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
            catch(Exception ex)
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
            catch(Exception ex)
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
