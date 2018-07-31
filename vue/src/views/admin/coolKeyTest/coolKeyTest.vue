<template>
    <div>
        <Card>
            <p slot="title">{{'POSTests'|0}}</p>
             
            <Dropdown slot="extra"  @on-click="handleClickActionsDropdown">
                <a href="javascript:void(0)">
                    {{'Actions'|l}}
                    <Icon type="android-more-vertical"></Icon>
                </a>
                <DropdownMenu slot="list">
                    <DropdownItem name='Refresh'>{{'Refresh'|l}}</DropdownItem>
                    <DropdownItem name='Create'>{{'Create'|l}}</DropdownItem>
                </DropdownMenu>
            </Dropdown>
            <Table :columns="columns" border :data="POSTests"></Table>
            <Page :total="totalCount" class="margin-top-10" @on-change="pageChange" @on-page-size-change="pagesizeChange" :page-size="pageSize" :current="currentPage" show-sizer></Page>
        </Card>
        <Modal v-model="showModal" :title="L('CreateNewUser')" @on-ok="save" :okText="L('save')" :cancelText="L('cancel')">
            <div>
                <Form ref="newUserForm" label-position="top"  :model="editUser">
                    <Tabs value="detail">
                        <TabPane :label="L('UserDetails')" name="detail">
                           
                            <FormItem :label="L('Name')" prop="name">
                                <Input v-model="editUser.name" :maxlength="32"></Input>
                            </FormItem>
                            <FormItem :label="L('sex')" prop="sex">
                                <Input v-model="editUser.sex" :maxlength="1024"></Input>
                            </FormItem>
                            <FormItem :label="L('age')" prop="age">
                                <Input v-model="editUser.age" ></Input>
                            </FormItem>
                            <FormItem :label="L('hight')" prop="hight">
                                <Input v-model="editUser.hight" ></Input>
                            </FormItem>
                        </TabPane>
                    </Tabs>
                    
                </Form>
            </div>
            <div slot="footer">
                <Button @click="showModal=false">{{'Cancel'|l}}</Button>
                <Button @click="save" type="primary">{{'Save'|l}}</Button>
            </div>
        </Modal>
        <Modal v-model="showEditModal" :title="L('EditUser')" @on-ok="save" :okText="L('save')" :cancelText="L('cancel')">
            <div>
                <Form ref="userForm" label-position="top"  :model="editUser">
                    <Tabs value="detail">
                        <TabPane :label="L('UserDetails')" name="detail">
                              <FormItem :label="L('Name')" prop="name">
                                <Input v-model="editUser.name" :maxlength="32"></Input>
                            </FormItem>
                            <FormItem :label="L('sex')" prop="sex">
                                <Input v-model="editUser.sex" :maxlength="1024"></Input>
                            </FormItem>
                            <FormItem :label="L('age')" prop="age">
                                <Input v-model="editUser.age" ></Input>
                            </FormItem>
                            <FormItem :label="L('hight')" prop="hight">
                                <Input v-model="editUser.hight" ></Input>
                            </FormItem>
                        </TabPane>
                    </Tabs>                    
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
            this.editUser={};
            this.showModal=true;
        },
        async save(){
            if(!!this.editUser.id){
                this.$refs.userForm.validate(async (val)=>{
                    if(val){
                        await this.$store.dispatch({
                            type:'POSTest/update',
                            data:this.editUser
                        })
                        this.showEditModal=false;
                        await this.getpage();
                    }
                })
                
            }else{
                this.$refs.newUserForm.validate(async (val)=>{
                    if(val){
                        await this.$store.dispatch({
                            type:'POSTest/create',
                            data:this.editUser
                        })
                        this.showModal=false;
                        await this.getpage();
                    }
                })
            }
            
        },
        pageChange(page){
            this.$store.commit('POSTest/setCurrentPage',page);
            this.getpage();
        },
        pagesizeChange(pagesize){
            this.$store.commit('POSTest/setPageSize',pagesize);
            this.getpage();
        },
        async getpage(){
            await this.$store.dispatch({
                type:'POSTest/getListAsync'
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
            editUser:{},
            showModal:false,
            showEditModal:false,
            columns:[{
                title:this.L('Name'),
                key:'name'
            },{
                title:this.L('Sex'),
                key:'sex'
            },{
                title:this.L('Age'),
                key:'age'
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
                                    this.editUser=this.POSTests[params.index];
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
                                        content:this.L('Delete user'),
                                        okText:this.L('Yes'),
                                        cancelText:this.L('No'),
                                        onOk:async()=>{
                                            await this.$store.dispatch({
                                                type:'POSTest/delete',
                                                data:this.POSTests[params.index]
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
        POSTests(){
            return this.$store.state.POSTest.POSTests;
        },
        
        totalCount(){
            return this.$store.state.POSTest.totalCount;
        },
        currentPage(){
            return this.$store.state.POSTest.currentPage;
        },
        pageSize(){
            return this.$store.state.POSTest.pageSize;
        }
    },
    async created(){
        this.getpage();
    }
}
</script>


