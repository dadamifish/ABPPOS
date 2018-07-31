import Cookies from 'js-cookie';
import Util from '@/libs/util'
import appconst from '@/libs/appconst'
const POSTest = {
    namespaced:true,
    state: {
        POSTests:[],
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
        async getListAsync({state},payload){
            let page={
                maxResultCount:state.pageSize,
                skipCount:(state.currentPage-1)*state.pageSize
            }
            let rep= await Util.ajax.get('/api/services/app/FT.POSTest/GetListAsync',{params:page});
            state.POSTests=[];
            state.POSTests.push(...rep.data.result.items);
            state.totalCount=rep.data.result.totalCount;
        },
        async delete({state},payload){
            await Util.ajax.delete('/api/services/app/FT.POSTest/Delete?Id='+payload.data.id);
        },
        async create({state},payload){
            await Util.ajax.post('/api/services/app/FT.POSTest/Create',payload.data);
        },
        async update({state},payload){
            await Util.ajax.put('/api/services/app/FT.POSTest/Update',payload.data);
        }
    }
};

export default POSTest;
