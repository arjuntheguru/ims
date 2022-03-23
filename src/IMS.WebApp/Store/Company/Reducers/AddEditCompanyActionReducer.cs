using Fluxor;
using IMS.Application.Companies.DTOs;
using IMS.WebApp.Store.Company.Actions.AddCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Store.Company.Reducers
{
    public class AddEditCompanyActionReducer
    {
        [ReducerMethod]
        public static CompanyState ReduceAddCompanyAction(CompanyState state, AddEditCompanyAction _) =>
            state with
            {
                IsLoading = true
            };


        [ReducerMethod]
        public static CompanyState ReduceAddCompanySuccessAction(CompanyState state, AddEditCompanySuccessAction _) =>
            state with
            {
                IsLoading = false
            };

        [ReducerMethod]
        public static CompanyState ReduceAddCompanyFailureAction(CompanyState state, AddEditCompanyFailureAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = action.ErrorMessage
            };

    }
}
