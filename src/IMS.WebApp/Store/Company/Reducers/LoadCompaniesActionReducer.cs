using Fluxor;
using IMS.WebApp.Store.Company.Actions.LoadCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Store.Company.Reducers
{
    public class LoadCompaniesActionReducer
    {
        [ReducerMethod]
        public static CompanyState ReduceLoadCompaniesAction(CompanyState state, LoadCompaniesAction action) =>
            state with
            {
                IsLoading = true,
                CurrentPage = action.PageNumber
            };

        [ReducerMethod]
        public static CompanyState ReduceLoadCompaniesSuccessAction(CompanyState state, LoadCompaniesSuccessAction action) =>
            state with
            {
                IsLoading = false,
                CurrentCompanies = action.Companies,
                CurrentCompany = action.Companies.FirstOrDefault(),
                TotalRecords = action.TotalRecords
            };

        [ReducerMethod]
        public static CompanyState ReduceLoadCompaniesFailureAction(CompanyState state, LoadCompaniesFailureAction action) =>
           state with
           {
               IsLoading = false,
               CurrentErrorMessage = action.ErrorMessage
           };
    }
}
