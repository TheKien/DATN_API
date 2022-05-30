using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Common;
using MISA.Core.Interfaces.Service;
using MISA.Core.Services;
using MISA.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Api.Controllers
{
    /// <summary>
    /// api BaseEntities - gồm các api dùng chung của các đối tượng
    /// createdBy: namnguyen(15/01/2022)
    /// </summary>
    ///
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntitiesController<TEntity> : ControllerBase
    {
        IBaseService<TEntity> _baseService;
        CommonFunction commonfunc = new CommonFunction();
        public BaseEntitiesController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// api lấy tất cả đối tượng
        /// </summary>
        /// <returns>danh sách đối tượng</returns>
        /// createdBy: namnguyen(15/01/2022)
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                string permissionCode = $"{typeof(TEntity).Name}_view";
                if (checkPermissionUser(permissionCode))
                {
                    var entities = _baseService.GetEntities();
                    return Ok(entities);

                }
                else
                {
                    return Ok(Core.Enums.MISAEnum.MISACode.Unauthorized);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        /// <summary>
        /// api lấy đối tượng theo Id
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <returns>1 đối tượng tương ứng với Id</returns>
        /// createdBy: namnguyen(15/01/2022)
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var entity = _baseService.GetEntityById(Guid.Parse(id));
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// api thêm 1 một đối tượng
        /// </summary>
        /// <param name="entity">thông tin đối tượng thêm</param>
        /// createdBy: namnguyen(15/01/2022)
        [HttpPost]
        public IActionResult Post(TEntity entity)
        {
            try
            {
                string permissionCode = $"{typeof(TEntity).Name}_add";
                if (checkPermissionUser(permissionCode))
                {
                    var serviceResult = _baseService.Add(entity);
                    return Ok(serviceResult);

                }
                else
                {
                    return Ok(Core.Enums.MISAEnum.MISACode.Unauthorized);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            //var serviceResult = _baseService.Add(entity);
            //return Ok(serviceResult);

        }

        /// <summary>
        /// sửa đối tượng được lấy về từ DB theo Id
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <param name="entity">thông tin đối tượng sửa</param>
        /// createdBy: namnguyen(15/01/2022)
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id, [FromBody] TEntity entity)
        {
            try
            {

                string permissionCode = $"{typeof(TEntity).Name}_edit";
                if (checkPermissionUser(permissionCode))
                {
                    // lấy id đối tượng
                    var keyProperty = entity.GetType().GetProperty($"{typeof(TEntity).Name}Id");
                    // chuyển kiểu dữ liệu của Id đối tượng để tương ứng DB
                    if (keyProperty.PropertyType == typeof(Guid)) // nếu là kiểu Guid
                    {
                        keyProperty.SetValue(entity, Guid.Parse(id));
                    }
                    else if (keyProperty.PropertyType == typeof(int)) // nếu là kiểu Int
                    {
                        keyProperty.SetValue(entity, int.Parse(id));
                    }
                    else // khác
                    {
                        keyProperty.SetValue(entity, id);
                    }
                    // thực hiện update
                    var serviceResult = _baseService.Update(entity);
                    if (serviceResult.MISACode == Core.Enums.MISAEnum.MISACode.NotValid)
                    {
                        return BadRequest(serviceResult);
                    }
                    else
                    {
                        return Ok(serviceResult);
                    }

                }
                else
                {
                    return Ok(Core.Enums.MISAEnum.MISACode.Unauthorized);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        /// <summary>
        /// xóa một đối tượng theo Id
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// createdBy: namnguyen(15/01/2022)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                string permissionCode = $"{typeof(TEntity).Name}_delete";
                if (checkPermissionUser(permissionCode))
                {
                    var res = _baseService.Delete(id);
                    return Ok(res);
                }
                else
                {
                    return Ok(Core.Enums.MISAEnum.MISACode.Unauthorized);
                }       
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        /// <summary>
        /// hàm check quyền user
        /// </summary>
        /// <param name="permissionCode"></param>
        /// <returns></returns>
        protected Boolean checkPermissionUser(string permissionCode)
        {
            Boolean result = false;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("permission")))
            {
                string lstUserPermission = HttpContext.Session.GetString("permission");
                if (commonfunc.checkPermissionUser(lstUserPermission.ToLower(), permissionCode.ToLower()))
                {
                    result = true;
                }
            }
            return result;

        }
    }
}
