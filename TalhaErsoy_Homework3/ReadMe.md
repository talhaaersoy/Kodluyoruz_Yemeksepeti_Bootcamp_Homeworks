## Readonly

-Readonly veri tipi uygulama çalışırken değeri değiştirilmeyecek bir değişken tanımlamamız gerektiğinde kullanılır.

##  Var

-Var değişkeni,türü belirtilmemiş olan verilerin atandığı veri türüdür. 

-Verinin tipi derleyici tarafından atanır.

## Object (Boxing-Unboxing)

Object tipiyle oluşturduğumuz bir nesne RAM'e object veri tipinde kaydedilir.Bu duruma boxing denir.

```c#
object ahmet1 = "ahmet"; //Boxing

string ahmet2 = (string)ahmet1 //Unboxing
```

## Event

Bir buton nesnesine farenin sol tuşuyla tıkladığımızda,bir textbox nesnesine bir karakter girdiğimizde ya da fareyle combobax daki elemanlardan birini seçtiğimizde bir olay gerçekleşir.İşte bu durumların hepsi bir olaydır.
Şimdi formumuza bir Button nesnesi koyalım ve Click Eventına aşağıdaki şekilde ulaşalım.



```c#
private void Form1_Load(object sender, EventArgs e)
{
    button1.Click += new EventHandler(Tiklandi);
}
void Tiklandi(object sender, EventArgs e)
{
    Console.Writeline("Butona Tıklandı.")
}

```



## Try-Catch-Finally

-Birden fazla finally bloğu bulunamaz.

-Finally bloğundan herhangi bir şekilde çıkışa izin verilmez.(return,continue,break)

-Finally bloğu genellikle kodu temizlemek için kullanılır. Örnekteki gibi:

``` c#
static void Main(string[] args)
{
    FileInfo file = null;

    try
    {
        Console.Write("Enter a file name to write: ");
        string fileName = Console.ReadLine();
        file = new FileInfo(fileName);
        file.AppendText("Hello World!")
    }
    catch(Exception ex)
    {
        Console.WriteLine("Error occurred: {0}", ex.Message );
    }
    finally
    {
        // clean up file object here;
        file = null;
    }
}
```

# BONUS

## Tuple

**Tuple** custom bir class oluşturmadan üzerinde birden fazla specific değer tutabilen bir veri yapısıdır. Diğer bir değişle; geriye birden fazla parametre döndürmek istediğimiz bir metot var diyelim ve bu parametreler için normalde gidip custom bir nesne oluşturup sonra gidip bu nesneyi initialize edip property'lerini set'leyip metottan return ederdik veya bu bahsettiğimizi yeni bir object tanımlamadan **out** parametresini kullanarak da geriye döndürebilirdik ancak bir çok kişiye göre hem biraz maliyetli olarak kabul edilir hemde out async metotlarda kullanılamamaktadır. Bunun yerine daha basit ve anlaşılır olan tuple kullanarak çok rahat bir şekilde metottan geriye birden fazla parametre return edebiliyoruz.

```c#
Tuple<int, string, string> person =  new Tuple <int, string, string>(1, "Steve", "Jobs");
```

## Stream

Stream, dosyalardan,bellekten vb gibi kaynaklardan beri giriş çıkışını sağlayan classtır. 

Detaylı bilgi için  [Buraya Tıklayın](https://www.tutorialsteacher.com/csharp/csharp-stream-io)





