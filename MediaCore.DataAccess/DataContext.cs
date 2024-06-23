using MediaCore.Model.LocalMedia;
using MediaCore.Model.WebSite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Models;

namespace MediaCore.DataAccess
{
    public partial class DataContext : FrameworkContext
    {
        public DbSet<FrameworkUser> FrameworkUsers { get; set; }
        public DbSet<FrameworkUserRole> FrameworkUserRoles { get; set; }
        public DbSet<FrameworkUserGroup> FrameworkUserGroups { get; set; }

        public DbSet<LocalMediaInfo> LocalMediaInfos { get; set; }
        public DbSet<LocalMediaConfig> LocalMediaConfig { get; set; }

        public DbSet<SiteMainConfig> SiteMainConfig { get; set; }



        public DataContext(CS cs)
             : base(cs)
        {
        }

        public DataContext(string cs, DBTypeEnum dbtype) : base(cs, dbtype)
        {

        }

        public DataContext(string cs, DBTypeEnum dbtype, string version = null) : base(cs, dbtype, version)
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public override async Task<bool> DataInit(object allModules, bool IsSpa)
        {
            var state = await base.DataInit(allModules, IsSpa);
            bool emptydb = false;
            try
            {
                emptydb = Set<FrameworkUser>().Count() == 0 && Set<FrameworkUserRole>().Count() == 0;
            }
            catch { }
            if (state == true || emptydb == true)
            {
                //when state is true, means it's the first time EF create database, do data init here
                //当state是true的时候，表示这是第一次创建数据库，可以在这里进行数据初始化
                var user = new FrameworkUser
                {
                    ITCode = "admin",
                    Password = Utils.GetMD5String("000000"),
                    IsValid = true,
                    Name = "Admin",

                };

                var userrole = new FrameworkUserRole
                {
                    UserCode = user.ITCode,
                    RoleCode = "001"
                };
                Set<FrameworkUser>().Add(user);
                Set<FrameworkUserRole>().Add(userrole);
                await SaveChangesAsync();

                try
                {
                    Dictionary<string, List<object>> data = new Dictionary<string, List<object>>();
                    new Task(() =>
                    {
                    }).Start();
                }
                catch { }
            }
            return state;
        }

        #region SetWorkflowData
        private void SetWorkflowData(string name, string modelname)
        {
            using (var dc = this.CreateNew())
            {
                dc.Set<Elsa_WorkflowDefinition>().Add(new Elsa_WorkflowDefinition
                {
                    ID = Guid.NewGuid().ToString("N").ToLower(),
                    DefinitionId = Guid.NewGuid().ToString("N").ToLower(),
                    Name = name,
                    Version = 1,
                    PersistenceBehavior = 1,
                    IsPublished = true,
                    IsLatest = true,
                    CreatedAt = DateTime.Now,
                    Data = $@"{{
                      ""$id"": ""1"",
                      ""activities"": [
                        {{
                          ""$id"": ""2"",
                          ""activityId"": ""eb10789a-536b-4335-acfe-ee2bfb888cbc"",
                          ""type"": ""WtmApproveActivity"",
                          ""displayName"": ""审批"",
                          ""persistWorkflow"": false,
                          ""loadWorkflowContext"": false,
                          ""saveWorkflowContext"": false,
                          ""properties"": [
                            {{
                              ""$id"": ""3"",
                              ""name"": ""ApproveUsers"",
                              ""expressions"": {{
                                ""$id"": ""4"",
                                ""Json"": ""[\""admin\""]""
                              }}
                            }},
                            {{
                              ""$id"": ""5"",
                              ""name"": ""ApproveRoles"",
                              ""expressions"": {{
                                ""$id"": ""6""
                              }}
                            }},
                            {{
                              ""$id"": ""7"",
                              ""name"": ""ApproveGroups"",
                              ""expressions"": {{
                                ""$id"": ""8""
                              }}
                            }},
                            {{
                              ""$id"": ""9"",
                              ""name"": ""ApproveManagers"",
                              ""expressions"": {{
                                ""$id"": ""10""
                              }}
                            }},
                            {{
                              ""$id"": ""11"",
                              ""name"": ""ApproveSpecials"",
                              ""expressions"": {{
                                ""$id"": ""12""
                              }}
                            }},
                            {{
                              ""$id"": ""13"",
                              ""name"": ""Tag"",
                              ""expressions"": {{
                                ""$id"": ""14""
                              }}
                            }}
                          ],
                          ""propertyStorageProviders"": {{
                            ""$id"": ""15""
                          }}
                        }},
                        {{
                          ""$id"": ""16"",
                          ""activityId"": ""e52df4f2-2da7-43ac-973a-76618072eec2"",
                          ""type"": ""Finish"",
                          ""displayName"": ""结束"",
                          ""persistWorkflow"": false,
                          ""loadWorkflowContext"": false,
                          ""saveWorkflowContext"": false,
                          ""properties"": [
                            {{
                              ""$id"": ""17"",
                              ""name"": ""ActivityOutput"",
                              ""expressions"": {{
                                ""$id"": ""18""
                              }}
                            }},
                            {{
                              ""$id"": ""19"",
                              ""name"": ""OutcomeNames"",
                              ""expressions"": {{
                                ""$id"": ""20""
                              }}
                            }}
                          ],
                          ""propertyStorageProviders"": {{
                            ""$id"": ""21""
                          }}
                        }}
                      ],
                      ""connections"": [
                        {{
                          ""$id"": ""22"",
                          ""sourceActivityId"": ""eb10789a-536b-4335-acfe-ee2bfb888cbc"",
                          ""targetActivityId"": ""e52df4f2-2da7-43ac-973a-76618072eec2"",
                          ""outcome"": ""同意""
                        }},
                        {{
                          ""$id"": ""23"",
                          ""sourceActivityId"": ""eb10789a-536b-4335-acfe-ee2bfb888cbc"",
                          ""targetActivityId"": ""e52df4f2-2da7-43ac-973a-76618072eec2"",
                          ""outcome"": ""拒绝""
                        }}
                      ],
                      ""variables"": {{
                        ""$id"": ""24"",
                        ""data"": {{}}
                      }},
                      ""contextOptions"": {{
                        ""$id"": ""25"",
                        ""contextType"": ""{modelname}"",
                        ""contextFidelity"": ""Burst""
                      }},
                      ""customAttributes"": {{
                        ""$id"": ""26"",
                        ""data"": {{}}
                      }}
                    }}"
                });
                try
                {
                    dc.SaveChanges();
                }
                catch { }
            }
        }
        #endregion



        /// <summary>
        /// DesignTimeFactory for EF Migration, use your full connection string,
        /// EF will find this class and use the connection defined here to run Add-Migration and Update-Database
        /// </summary>
        public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
        {
            public DataContext CreateDbContext(string[] args)
            {
                return new DataContext("your full connection string", DBTypeEnum.SqlServer);
            }
        }

    }
}