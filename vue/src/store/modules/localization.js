import Cookies from 'js-cookie';
import Util from '@/libs/util'
import appconst from '@/libs/appconst'
const model = {
    namespaced:true,
    state: {
        baseUrl:'/api/services/app/Language/',
        localizations:[],
        totalCount:0,
        pageSize:10,
        currentPage:1
    },
    mutations: {
        setPageSize(state,size){
            state.pageSize=size;
        },
        setCurrentPage(state,page){
            state.currentPage=page;
        }
    },
    actions:{
        async getLanguages({state},payload){
            let page={
                maxResultCount:state.pageSize,
                skipCount:(state.currentPage-1)*state.pageSize
            }
            let rep= await Util.ajax.get(state.baseUrl+'GetLanguages',{params:page});
            state.localizations=[];
            state.localizations.push(...rep.data.result.items);
            state.totalCount=rep.data.result.totalCount;
        },
        async delete({state},payload){
            await Util.ajax.delete(state.baseUrl+'DeleteLanguage?Id='+payload.data.id);
        },
        async create({state},payload){
            await Util.ajax.post(state.baseUrl+'GetLanguageForEdit',payload.data);
        },
        async update({state},payload){
            await Util.ajax.put(state.baseUrl+'SetDefaultLanguage',payload.data);
        }
    }
};

export default model;
