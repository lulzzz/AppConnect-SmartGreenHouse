﻿using iot.solution.entity.Structs.Routes;
using iot.solution.service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Entity = iot.solution.entity;
using Model = iot.solution.model.Models;
namespace host.iot.solution.Controllers
{
    [Route(GreenHouseRoute.Route.Global)]
    public class GreenHouseController : BaseController
    {
        private readonly IGreenHouseService _service;

        public GreenHouseController(IGreenHouseService greenHouseService)
        {
            _service = greenHouseService;
        }

        [HttpGet]
        [Route(GreenHouseRoute.Route.GetList, Name = GreenHouseRoute.Name.GetList)]
        public Entity.BaseResponse<List<Entity.GreenHouse>> Get(bool isAdmin,bool? isActive)
        {
            Entity.BaseResponse<List<Entity.GreenHouse>> response = new Entity.BaseResponse<List<Entity.GreenHouse>>(true);
            try
            {
                response.Data = _service.Get(isAdmin,isActive);
            }
            catch (Exception ex)
            {
                base.LogException(ex);
                return new Entity.BaseResponse<List<Entity.GreenHouse>>(false, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route(GreenHouseRoute.Route.GetById, Name = GreenHouseRoute.Name.GetById)]
        public Entity.BaseResponse<Entity.GreenHouse> Get(Guid id)
        {
            Entity.BaseResponse<Entity.GreenHouse> response = new Entity.BaseResponse<Entity.GreenHouse>(true);
            try
            {
                response.Data = _service.Get(id);
            }
            catch (Exception ex)
            {
                base.LogException(ex);
                return new Entity.BaseResponse<Entity.GreenHouse>(false, ex.Message);
            }
            return response;
        }
       
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [HttpPost]
        [Route(GreenHouseRoute.Route.Manage, Name = GreenHouseRoute.Name.Add)]
        public Entity.BaseResponse<Entity.GreenHouse> Manage([FromForm]Entity.GreenHouseModel request)
        {
            Entity.BaseResponse<Entity.GreenHouse> response = new Entity.BaseResponse<Entity.GreenHouse>(true);
            try
            {
                var status = _service.Manage(request);
                response.IsSuccess = status.Success;
                response.Message = status.Message;
                response.Data = status.Data;
            }
            catch (Exception ex)
            {
                base.LogException(ex);
                return new Entity.BaseResponse<Entity.GreenHouse>(false, ex.Message);
            }
            return response;
        }

        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [HttpPut]
        [Route(GreenHouseRoute.Route.Delete, Name = GreenHouseRoute.Name.Delete)]
        public Entity.BaseResponse<bool> Delete(Guid id)
        {
            Entity.BaseResponse<bool> response = new Entity.BaseResponse<bool>(true);
            try
            {
                var status = _service.Delete(id);
                response.IsSuccess = status.Success;
                response.Message = status.Message;
                response.Data = status.Success;
            }
            catch (Exception ex)
            {
                base.LogException(ex);
                return new Entity.BaseResponse<bool>(false, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route(GreenHouseRoute.Route.BySearch, Name = GreenHouseRoute.Name.BySearch)]
        public Entity.BaseResponse<Entity.SearchResult<List<Entity.GreenHouseDetail>>> GetBySearch(string searchText = "", int? pageNo = 1, int? pageSize = 10, string orderBy = "")
        {
            Entity.BaseResponse<Entity.SearchResult<List<Entity.GreenHouseDetail>>> response = new Entity.BaseResponse<Entity.SearchResult<List<Entity.GreenHouseDetail>>>(true);
            try
            {
                response.Data = _service.List(new Entity.SearchRequest()
                {
                    SearchText = searchText,
                    PageNumber = pageNo.Value,
                    PageSize = pageSize.Value,
                    OrderBy = orderBy
                });
            }
            catch (Exception ex)
            {
                base.LogException(ex);
                return new Entity.BaseResponse<Entity.SearchResult<List<Entity.GreenHouseDetail>>>(false, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route(GreenHouseRoute.Route.UpdateStatus, Name = GreenHouseRoute.Name.UpdateStatus)]
        public Entity.BaseResponse<bool> UpdateStatus(Guid id, bool status)
        {
            Entity.BaseResponse<bool> response = new Entity.BaseResponse<bool>(true);
            try
            {
                Entity.ActionStatus result = _service.UpdateStatus(id, status);
                response.IsSuccess = result.Success;
                response.Message = result.Message;
                response.Data = result.Success;
            }
            catch (Exception ex)
            {
                base.LogException(ex);
                return new Entity.BaseResponse<bool>(false, ex.Message);
            }
            return response;
        }

    }
}