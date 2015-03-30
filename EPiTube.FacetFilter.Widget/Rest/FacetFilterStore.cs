﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer.Cms.Shell.UI.Rest.ContentQuery;
using EPiServer.Core;
using EPiServer.Globalization;
using EPiServer.Security;
using EPiServer.Shell.Services.Rest;
using EPiTube.facetFilter.Core;
using EPiTube.FacetFilter.Core.Service;

namespace EPiTube.facetFilter.Widget.Rest
{
    [RestStore("facetfilter")]
    public class facetFilterStore : RestControllerBase
    {
        private readonly FacetService _facetService;

        public facetFilterStore(FacetService facetService)
        {
            _facetService = facetService;
        }

        [HttpGet]
        public RestResult Get(
            ContentReference id,
            string query,
            ContentReference referenceId,
            //string[] typeIdentifiers,
            //bool? allLanguages,
            IEnumerable<SortColumn> sortColumns,
            ItemRange range)
        {
            var queryParameters = new ContentQueryParameters
            {
                ReferenceId = referenceId,
                //AllLanguages = allLanguages.GetValueOrDefault(),
                //TypeIdentifiers = typeIdentifiers,
                SortColumns = sortColumns,
                Range = range,
                AllParameters = ControllerContext.HttpContext.Request.QueryString,
                CurrentPrincipal = PrincipalInfo.CurrentPrincipal,
                //PreferredCulture = allLanguages.GetValueOrDefault() ? null : ContentLanguage.PreferredCulture
            };

            var filterOptions = _facetService.GetItems(queryParameters).ToList();
            return Rest(filterOptions);
        }
    }
}