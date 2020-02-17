﻿using System;
using System.Collections.Generic;
using Entity = iot.solution.entity;
using Model = iot.solution.model.Models;
using Response = iot.solution.entity.Response;

namespace iot.solution.model.Repository.Interface
{
    public interface ICropRepository : IGenericRepository<Model.Crop>
    {
        Entity.SearchResult<List<Model.Crop>> List(Entity.SearchRequest request);
        List<Response.GreenHouseCropResponse> GetGreenHouseCorps(Guid greenhouseId);
    }
}
