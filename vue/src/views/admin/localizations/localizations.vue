<template>
    <div>
        <Card>
            <p slot="title">{{'Localizations'|l}}</p>
            <Dropdown slot="extra"  @on-click="handleClickActionsDropdown">
                <a href="javascript:void(0)">
                    {{'Actions'|l}}
                    <Icon type="android-more-vertical"></Icon>
                </a>
                <DropdownMenu slot="list">
                    <DropdownItem name='Refresh'>{{'Refresh' | l}}</DropdownItem>
                    <DropdownItem name='Create'>{{'Create' | l}}</DropdownItem>
                </DropdownMenu>
            </Dropdown>
            <Table :columns="columns" border :data="localizations"></Table>
            <Page :total="totalCount" class="margin-top-10" @on-change="pageChange" @on-page-size-change="pagesizeChange" :page-size="pageSize" :current="currentPage"></Page>
        </Card>
        <Modal v-model="showModal" :title="L('CreateNewRole')" @on-ok="save" :okText="L('save')" :cancelText="L('cancel')">
            <div>
                <Form ref="newform" label-position="top" :rules="newrule" :model="editModel">
                    <FormItem :label="L('Actions')" prop="name">
                        <Input v-model="editModel.name" :maxlength="32" :minlength="2" />
                    </FormItem>
                    <FormItem :label="L('DisplayName')" prop="displayName">
                        <Input v-model="editModel.displayName" :maxlength="32" :minlength="2" />
                    </FormItem>
                    <FormItem :label="L('IsDisabled')" prop="isDisabled">
                        <Input v-model="editModel.isDisabled" />
                    </FormItem>             
                </Form>
            </div>
            <div slot="footer">
                <Button @click="showModal=false">{{'Cancel'|l}}</Button>
                <Button @click="save" type="primary">{{'Save'|l}}</Button>
            </div>
        </Modal>
        <Modal v-model="showEditModal" :title="L('editModel')" @on-ok="save" :okText="L('save')" :cancelText="L('cancel')">
            <div>
                <Form ref="form" label-position="top" :rules="rule" :model="editModel">
                    <FormItem :label="L('Name')" prop="name">
                        <Input v-model="editModel.name" :maxlength="32" :minlength="2" />
                    </FormItem>
                    <FormItem :label="L('DisplayName')" prop="displayName">
                        <Input v-model="editModel.displayName" :maxlength="32" :minlength="2" />
                    </FormItem>
                    <FormItem :label="L('IsDisabled')" prop="isDisabled">
                        <Input v-model="editModel.isDisabled" />
                    </FormItem>                
                </Form>
            </div>
            <div slot="footer">
                <Button @click="showEditModal=false">{{'Cancel'|l}}</Button>
                <Button @click="save" type="primary">{{'Save'|l}}</Button>
            </div>
        </Modal>
    </div>
</template>
<script>
export default {
    methods:{
        create(){
            this.editModel={isActive:true};
            this.showModal=true;
        },
        async save(){
            if(!!this.editModel.id){
                this.$refs.form.validate(async (val)=>{
                    if(val){
                        await this.$store.dispatch({
                            type:'localization/update',
                            data:this.editModel
                        })
                        this.showEditModal=false;
                        await this.getpage();
                    }
                })
                
            }else{
                this.$refs.newform.validate(async (val)=>{
                    if(val){
                        await this.$store.dispatch({
                            type:'localization/create',
                            data:this.editModel
                        })
                        this.showModal=false;
                        await this.getpage();
                    }
                })
            }
            
        },
        pageChange(page){
            this.$store.commit('localization/setCurrentPage',page);
            this.getpage();
        },
        pagesizeChange(pagesize){
            this.$store.commit('localization/setPageSize',pagesize);
            this.getpage();
        },
        async getpage(){
            await this.$store.dispatch({
                type:'localization/getLanguages'
            })
        },
        handleClickActionsDropdown(name){
            if(name==='Create'){
                this.create();
            }else if(name==='Refresh'){
                this.getpage();
            }
        }
    },
    data(){
        return{
            editModel:{},
            showModal:false,
            showEditModal:false,
            newrule:{
                name:[{required:true,message:'Name is required',trigger: 'blur'}],
                displayName:[{required:true,message:'DisplayName is required',trigger: 'blur'}],
            },            
            rule:{
                name:[{required:true,message:'Name is required',trigger: 'blur'}],
                displayName:[{required:true,message:'DisplayName is required',trigger: 'blur'}],
            },
            columns:[{
                title:this.L('Name'),
                key:'name'
            },{
                title:this.L('DisplayName'),
                key:'displayName'
            },{
                title: this.L('Actions'),
                key: 'action',
                width:150,
                render:(h,params)=>{
                    return h('div',[
                        h('Button',{
                            props:{
                                type:'primary',
                                size:'small'
                            },
                            style:{
                                marginRight:'5px'
                            },
                            on:{
                                click:()=>{
                                    this.editModel=this.localizations[params.index];
                                    this.showEditModal=true;
                                }
                            }
                        },this.L('Edit')),
                        h('Button',{
                            props:{
                                type:'error',
                                size:'small'
                            },
                            on:{
                                click:async()=>{
                                    this.$Modal.confirm({
                                        title:this.L(''),
                                        content:this.L('Delete'),
                                        okText:this.L('Yes'),
                                        cancelText:this.L('No'),
                                        onOk:async()=>{
                                            await this.$store.dispatch({
                                                type:'localization/delete',
                                                data:this.localizations[params.index]
                                            })
                                            await this.getpage();
                                        }
                                    })
                                }
                            }
                        },this.L('Delete'))
                    ])
                }
            }]
        }
    },
    computed:{
        localizations(){
            return this.$store.state.localization.localizations;
        },
        totalCount(){
            return this.$store.state.localization.totalCount;
        },
        currentPage(){
            return this.$store.state.localization.currentPage;
        },
        pageSize(){
            return this.$store.state.localization.pageSize;
        }
    },
    async created(){
        this.getpage();
    }
}
</script>



