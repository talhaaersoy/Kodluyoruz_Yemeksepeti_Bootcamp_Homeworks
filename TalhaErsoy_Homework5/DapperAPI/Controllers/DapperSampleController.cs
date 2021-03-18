using Dapper;
using DapperAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Dapper.Transaction;

namespace DapperAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DapperSampleController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        string sqlConnection = @"Server=DESKTOP-FL5Q8JD\SQLExpress;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AdventureWorks2019.mdf;Database=AdventureWorks2019;Trusted_Connection=Yes;";

        public DapperSampleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("select")]
        public IActionResult Select()
        {
            //execute metodu ile databasede sorguyu çalıştırıyorum veritabanından datayı alıyorum ve controller'da kullanıcıya sunuyorum 
            string sql = $"Select * From [HumanResources].[Department];";
            using (IDbConnection db = new SqlConnection(sqlConnection))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }
                var department = db.Execute(sql);
              
                return Ok(department);
            }
        }
        [HttpPost("insert")]
        public IActionResult Insert([FromBody] Department department)
        {
            // insert sorgusu ile tablo satırlarını modelimdeki hangi değerlere karşılık geldiğini yazıyorum.
            //Execute komutu ile kullanıcıdan alınan nesneyi sql komutunun içine işliyorum
            string sql = $"INSERT INTO [HumanResources].[Department] (Name,GroupName,ModifiedDate) Values (@Name,@GroupName,@ModifiedDate)";
            using (IDbConnection db = new SqlConnection(sqlConnection))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }
                db.Execute(sql, department);

                return Ok();
            }
        }
        [HttpPost("update")]
        public IActionResult Update([FromBody] Department department)
        {
            // Update komutu ile tablo satırlarını modelimdeki hangi değerlere karşılık geldiğini yazıyorum.
            //Execute komutu ile kullanıcıdan alınan nesneyi sql komutunun içine işliyorum
            string sql = $"Update [HumanResources].[Department] Set Name = @Name,GroupName = @GroupName,ModifiedDate = @ModifiedDate Where DepartmentId= @DepartmentId;";
            using (IDbConnection db = new SqlConnection(sqlConnection))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }
                db.Execute(sql, department);

                return Ok();
            }
        }
        [HttpPost("deleteQuery")]
        public IActionResult DeleteQuery(int id)
        {
            //Query metodu ile veritabanından belitrilen id'deki nesneyi buluyor ve belitrtilen delete sorgusunu çalıştırıp nesneyi siliyorum.
            string sql = $"Delete From [HumanResources].[Department] Where DepartmentId= {id};";
            using (IDbConnection db = new SqlConnection(sqlConnection))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }
                db.Query<Department>(sql);

                return Ok();
            }

        }
        [HttpPost("delete")]
        public IActionResult Delete([FromBody] Department department)
        {
            //Execute komutu ile kullanıcıdan alınan nesneyi sql komutuna mapliyorum
            string sql = $"Delete From [HumanResources].[Department] Where DepartmentId= @DepartmentId;";
            using (IDbConnection db = new SqlConnection(sqlConnection))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }
                db.Execute(sql, department);


                return Ok();
            }
        }
        [HttpGet("GetAllSp")]
        public IActionResult GetAllSp()
        {
            /* 
            - STORED PROCEDURES-
           -Normal sorgulardan daha hızlı çalışırlar
           -Normal sorgular execute edilirken her sorguda Execute Plan işlemi yapılır.Ancak sorgu stored procedure ile çalıştırılırsa bu işlem bir kez yapılır 
            Dolayısıyla Performans artışı sağlanır

            CREATE PROCEDURE GetAllDepartmentSP
            AS
            BEGIN
               SELECT * FROM HumanResources.Department
            END

            -Yukardaki sorguyla database tarafında bir stored procedure oluşturdum 
            -Query Komutu ile Komutun typeni ve belirtilen typteki komutun ismini girerek gerekli sorguya ulaştım ve Controller üstünden kullanıcıya sundum.
             */
            using (IDbConnection db = new SqlConnection(sqlConnection))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }
                var result = db.Query<Department>("GetAllDepartmentSP", commandType: CommandType.StoredProcedure);

                return Ok(result);
            }
        }
        [HttpPost("insertTransaction")]
        public IActionResult InsertTransaction([FromBody]Department department)
        {
            /*
             -TRANSACTİON-  
            --Birden falza işlemin bir arada yapıldığı durumlarda eğer parçayı oluşturan işlemlerden herhangi birinde sorun olursa
            tüm parçaları iptal etmeye yarayan komuttur.--


            -Öncelikle dapper.transaction eklentisini yükledim
            -Bir using kulannarak transactiona bağlantıyı oluşturdum ve içine execute komutlarını yazdım ve transaction commit komutuyla transactionı kapattım.
            -Transactionın begin ve transaction commit komutları arasındaki komutlardan bir tanesinde hata çıkması durumunda bütün yapılan işlemler iptal olacaktı.
             */
            string sql1 = "INSERT INTO [HumanResources].[Department] (Name,GroupName,ModifiedDate) Values (@Name,@GroupName,@ModifiedDate)";
            string sql2 = "INSERT INTO [HumanResources].[EmployeeDepartmentHistory] (BusinessEntityId,DepartmentId,ShiftId,StartDate,EndDate,ModifiedDate)" +
                " Values (@BusinessEntityId,@DepartmentId,@ShiftId,@StartDate,@EndDate,@ModifiedDate);" ;
            using (IDbConnection db = new SqlConnection(sqlConnection))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }
                using (var transaction = db.BeginTransaction())
                {
                    transaction.Execute(sql1, department);
                    transaction.Execute(sql2, new EmployeeDepartmentHistory { BusinessEntityId = 200, DepartmentId = 1,ModifiedDate = DateTime.Now,StartDate = DateTime.UtcNow ,ShiftId = 1}) ;

                    transaction.Commit();

                }
            }
            return Ok();
        }
        [HttpGet("resultmapping")]
        public IActionResult ResultMapping(int id)
        {
            //Query metodu ile veritabanından datayı alıyorum ve model mappingini yaparak modelimi dolduruyorum. Son olarak doldurulan nesneyi cliente sunuyorum
            string sql = $"Select * From [HumanResources].[Department] Where DepartmentId ={id};";
            using (IDbConnection db = new SqlConnection(sqlConnection))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }
                var department = db.Query<Department>(sql);

                return Ok(department);
            }
        }
        [HttpGet("onetoone")]
        public IActionResult OneToOne()
        {
            /*
             İki tabloyu inner join sorgusuyla birleştirdim query komutu  burada func predicatei gibi çalışır. ve dışarıya bir Department nesnesi döner
            d department nesnesini simgeler ve d splitOn ile belirttiğimiz sütunun sol tarafını ed'yi ise sağ tarafına mapler biz bir department nesnesi istediğimiz için
            arrow functin d'yi geri döner.İşlem sonucunda tahmin edeceğiniz gibi çok fazla aynı nesneden döndü distinc komutu ile her nesneden 1 tane olmasını sağladık
             */
            var sql = "select Name,d.GroupName,d.DepartmentID,d.ModifiedDate,e.BusinessEntityID,e.EndDate,e.ModifiedDate,e.ShiftID,e.StartDate " +
                "from [HumanResources].Department d inner join HumanResources.EmployeeDepartmentHistory  e on d.DepartmentId = e.DepartmentId;";
            using (IDbConnection db = new SqlConnection(sqlConnection))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }
                var department = db.Query<Department,EmployeeDepartmentHistory,Department>(sql, (d,ed) => {
                    return d;
                },splitOn: "BusinessEntityID").Distinct();
                return Ok(department);
            }
        }
        [HttpGet("onetomany")]
        public IActionResult OneToMany()
        {
            /*
              Mapleme mantığı  yukarıdaki one to one ile aynı işliyor.
            Diğer işlemlere gelecek olursak distinct işlemi uygulamak yerine değerleri bir dictionarye atıyoruz arrow functionda tryget ile department idye eşit bir key var mı
            kontrol ediyoruz varsa dictionarye eklemiyoruz ancak yoksa if'in içine girip add işlemini yapıyoruz. ve en son kullanıcıya dctionaryi listeye çevirip kulannıcıya sunuyoruz
             */
            var sql = "select * from [HumanResources].Department d inner join HumanResources.EmployeeDepartmentHistory  e on d.DepartmentId = e.DepartmentId;";
            using (IDbConnection db = new SqlConnection(sqlConnection))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }
                var departmentDictionary = new Dictionary<int, Department>();
                var list = db.Query<Department, EmployeeDepartmentHistory, Department>(sql, (d, ed) => {
                    Department department;
                    if(!departmentDictionary.TryGetValue(d.DepartmentID,out department))
                    {
                        departmentDictionary.Add(d.DepartmentID, department = d);

                    }
                    return department;
                }, splitOn: "BusinessEntityID").Distinct();
                return Ok(departmentDictionary.ToList());
            }
        }
        [HttpGet("multiplequerymapping")]
        public IActionResult MultipleQueryMapping(int id)
        {

            /*
              Burada iki farklı tabloya iki farklı sorgu gönderdim ve bir using ile bu sorguyu açtım.
            bu usingin içinde nesnelerimize uygun tabloları dapper mapledi. 
             
             */
            string sql = $"Select * from [HumanResources].[Department] where DepartmentId = @DepartmentId ;" +
                $"Select * from [HumanResources].[EmployeeDepartmentHistory] where DepartmentId =@DepartmentId;";
            using (IDbConnection db = new SqlConnection(sqlConnection))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }
                using(var multi = db.QueryMultiple(sql,new {DepartmentId = id}))
                {
                    var department = multi.Read<Department>();
                    var departmentHistory = multi.Read<EmployeeDepartmentHistory>().ToList();
                }
            }
            return Ok();

        }
       
    }
}
