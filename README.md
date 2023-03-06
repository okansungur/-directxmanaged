# C# and Managed DirectX

### Kodları Çalıştırmak
Gerekli olan kurulum dosyalarını GoogleDrive’da bulabilirsiniz. Takip ediyorsanız Managed DirectX teknolojisi ve bununla birlikte XNA teknolojileri artık kullanılmamaktadır. Yazılan kitap 2008 yılındaki zamanın  güncel teknolojilerine göre yazılmıştır. Bunun yerine daha hızlı ve lightweight ortamlar kullanılmaktadır. Gdevelop, Unity gibi. Güncel teknolojilerin takip edilmesi gerekmektedir. 

Uygulamalarımızın çalışabilmesi için, bilgisayarınızda Microsoft Visual Studio 2005, .Net Framework 2.0 ve örnek uygulamaları inceleyebilmek için de DirectX SDK’nın (August-2006) yüklü olması gerekir. Vmware workstation kullanarak uygulamaları ayağa kaldırabilirsiniz.



<p align="center">
  <img  src="https://github.com/okansungur/directxmanaged/blob/main/kapak.png" width=100% height=100% ><br/>
   Game Programming 2008
</p>


__Microsoft DirectX İsimalanları__

İsimalanlarını kütüphanelere benzetebiliriz. Kütüphanelerde bilim, edebiyat veya tarih ile ilgili olan kitaplar, bu başlıklar altında belirli bir bölümde, bir düzene göre toplanmışlardır. Hangi konuyla ilgili bilgi edinmek istiyorsak rahatlıkla o bölüme gidip aradığımız konuya ilişkin kitapları bulabiliriz. İsimalanlarında da aynı mantık geçerlidir. Uygulamalarımızda kullanacağımız sınıflar belirli isimalanları içerisinde yer almaktadır. Bu sınıfları uygulamalarımızda kullanabilmek için sınıfın bulunduğu isimalanını programımıza dahil etmemiz gerekmektedir.
Microsoft DirectX içerisinde uygulama geliştirirken faydalanacağımız isimalanları yer almaktadır. Bu isimalanlarının bazıları aşağıda yer almaktadır.
Microsoft.DirectX: Hiyerarşi olarak en üstte yer alan isimalanıdır.
Microsoft.DirectX.Direct3D: En çok kullanılan kütüphanelerden biri olup; üç boyutlu görüntüleri ekrana taşıyan sınıflar bu isimalanında yer almaktadır.
Microsoft.DirectX.Direct3D.Direct3DX: Bu isimalanında tamamlayıcı özellikte sınıflar yer almaktadır.
Microsoft.DirectX.DirectInput: İsimalanı ile mouse, klavye gibi aygıtların kontrolünü sağlayan sınıflar yer almaktadır.
Microsoft.DirectX.DirectPlay: İsimalanı, multiplayer oyunların yazılması için gerekli sınıfları içermektedir.
Microsoft.DirectX.DirectPlay.Voice: İsimalanı, sesli iletişim için gerekli olan sınıfları içerir.
Microsoft.DirectX.DirectSound: İsimalanı, ses eklemek ve bu seslere efekt vermek için kullanılır.
Bunların dışında da bazı isimalanları yer almaktadır.
“Microsoft.DirectX.AudioVideoPlayback;”,“Microsoft.DirectX.Diagnostics;”, “Microsoft.DirectX.Security;”, “Microsoft.DirectX.DirectDraw;”.


SoftwareVertexProcessing: Bütün köşe hesaplamalarının yazılım tarafından yapılacağını belirtir. İşlem çok yavaş gerçekleşir.
HardwareVertexProcessing:  Köşe hesaplamalarında donanımdan (ekran kartı) faydalanılacağı belirtilir. (Eğer ekran kartı bu özelliklere destek veriyorsa.) 
MixedVertexProcessing: Adı üzerinde, her iki özelliğin de kullanabileceğini belirtir.
BehaviorFlags : Device nesnesinin davranışını belirtir.  
PresentationParameters: Device nesnesinin uygulamayı tam ekran çalıştırıp çalıştıramayacağını belirtir.
SwapEffect.Flip:  Titreme  olmaması için verinin tamponlanıp tamponlanmayacağını gösterir. 


__3D-Koordinat Sistemleri__

OpenGL, sağ ele dayanan koordinat sistemi kullanırken, Direct3D sol ele dayanan bir koordinat sistemi kullanır. Her iki sistemde de +X sağa, –X ise sola doğru gider.
Sağ el ve sol el koordinat sistemleri arasındaki farka gelince; sağ eli kullanan koordinat sisteminde +Z ekrandan dışarı doğru gelirken, sol ele dayanan koordinat sisteminde +Z ekrandan uzaklaşır.
Örneğin; (9,-2,7) noktası için sol ele dayanan koordinat sistemi kullanıldığında; tanımlanan değer, 9 birim sağa 2 birim alta, 7 birim ekrana doğru olan noktayı temsil eder. Bir sonraki örneğimizde koordinat sistemlerini daha yakından inceleyeceğiz.

Sağ ele dayanan koordinat sisteminde sağ elimizin başparmağı X eksenini, diğer parmaklar ise Y eksenini gösterecek şekilde tutulduğunda, “Z ekseni” avuç içi yönünde ekrandan dışarıya doğru yönlenmektedir. Sol ele dayanan koordinat sisteminde ise yine başparmak X ekseni yönünde, diğer parmaklar y ekseni yönünde tutulduğunda avuç içi Z eksenini göstermekte yani ekrandan içeriye doğru yönlenmektedir. Direct3D sol-ele dayanan koordinat sistemini kullanmaktadır.

__Kamera Tanımlanması__

Bu bölümdeki uygulamamızda, üç-boyutlu nesne görüntülemek için, yani nesnelerin daha gerçekçi olabilmesi için kameranın nasıl tanımlandığını göstereceğiz. Bunun için bazı kavramları inceleyelim.
Projeksiyon: Ekranda görüntülenebilen alanı temsil eder. Direct3D bize iki farklı projeksiyon sunmaktadır.
1-Perspektif  Projeksiyon: En genel kullanılan türüdür. Z uzaklığı dikkate alınmaktadır. Yani ekrandan uzak nesneler küçük görünür. Nesneler ekrana yaklaştıkça büyüklükleri artmaktadır.
2-Ortogonal  Projeksiyon: Bu türde Z uzaklığı dikkate alınmamaktadır. Genellikle iki boyutlu oyunlarda bu projeksiyon türü kullanılır.
Projeksiyon türü tanımlanırken dikkat edilmesi gereken nokta, koordinat sisteminin seçilmesidir. Koordinat sistemleri bildiğiniz gibi sağ el koordinat sistemi ve sol el koordinat sistemi olarak ayrılmaktadır.
Projeksiyon türünü seçtikten sonra gerekli parametreler gönderilmelidir. Direct3D bunun için bize altı temel fonksiyon sunar. Bu fonksiyonlar matris değerler döndürürler.
A-Matrix.ortoRH, Matrix.ortoLH: Sağ el koordinat sistemine göre ortogonal projeksiyon ve sol el koordinat sistemine göre ortogonal projeksiyonu temsil eder.
B-Matrix.perspectiveRH, Matrix.perspectiveLH: Sağ el koordinat sistemine göre perspektif projeksiyon ve sol el koordinat sistemine göre perspektif projeksiyonu temsil eder.
Matrislere göre boyutlandırma ve döndürme gibi işlemler kolaylıkla yapılabilmektedir.
C-Matrix.PerspectiveFovRH, Matrix.PerspectiveFovLH: Perspektif projeksiyona göre matris değer döndürür.
Radyan cinsinden bakış açısı ve z uzaklığı parametre olarak gönderilir. Sağ veya sol ele dayalı koordinat sistemi kullanılabilir. Matrisler konusunu ilerleyen bölümlerde detaylı bir şekilde inceleyeceğiz. Ancak matrisler konusunda, bulunduğumuz aşamada, aşağıdakilerin bilinmesi önemlidir.
1-Dönüşüm matrisleri kendi aralarında çarpma işlemi gerçekleştirir. Örneğin nesneyi döndürmek ve çevirmek için matris çarpımı gerçekleştirmemiz gerekmektedir. 
2-Device nesnesine ait üç temel özelliğin bilinmesinde fayda vardır.
Dönüşümler(Transformation), nesneleri bir koordinat alanından, başka bir koordinat alanına taşımak için kullanılan matrislerdir. Bunlar Direct3D isimalanında yer almaktadırlar.
device.Transform.Projection: Sahnenin monitörde nasıl görüntüleneceğini belirtmek için kullanılır( Kameranın lensi gibi düşünebiliriz ).
device.Transform.View: Kameranın sahnedeki konumunu belirtmektedir.
device.Transform.World: Bu dönüşümde köşeler, dünya koordinatlarına yerleştirilirler. Bu tür bir dönüşüm sayesinde boyutlandırma, döndürme(hareket) gibi kombinasyonlar yapılabilmektedir. Örneğin çizilen bir nesneyi Z ekseni yönünde döndürmek için 
“device.Transform.World = Matrix.RotationZ(aci/ (float)Math.PI);”
ifadesini kullanabiliriz. Buradaki açı değişkeni, önceden tanımlanmalı ve değeri belirli bir oranda arttırılmalıdır.
Kamera Pozisyonu: Görünüm matrisi DirectX’te kamera olarak tanımlanır. device.Transform.View ile kameranın sahneye yerleştirilebilineceğini daha önceden belirtmiştik. Eğer kamera tanımlanmazsa DirectX bizim için varsayılan bir matris tanımlamaktadır. Ancak bu hazırlayacağımız oyun veya simülasyon için çok sağlıklı olmayacaktır.


__Sahneye İlk Işığı Ekleme__

Işık kavramı oyunlarda oldukça önemlidir. Farklı ışık türleri vardır ve bu ışık türlerini daha sonraki uygulamalarımızda inceleyeceğiz. Ancak buradaki örneğimizde, basitçe sahnedeki üçgenleri aydınlatmak için nasıl bir yol izlenmesi gerektiği üzerinde duracağız ve konuya kısaca bir giriş yapacağız.
   device.Lights[0].Type = LightType.Point;
Uygulamamızda öncelikle ışığın türünü belirtiyoruz. Noktasal (point) bir ışık kaynağı seçiyoruz. Bu sayede ışık tüm yönlere eşit miktarda dağılacaktır. Yanan bir ampulü bu ışık türüne örnek olarak gösterebiliriz. Başka tür ışıklarda vardır. Örneğin, belirli yönde sonsuza dek hareket eden (directional) güneş ışığı gibi. Burada ışığın yönü ve rengi önem taşımaktadır. Son olarak spot ışıktan bahsedilebilinir. Genelde herhangi bir nesneyi sahnede ışıklandırmak için kullanılmaktadır.
VertexBuffer Sınıfı
Render işlemi esnasında, köşeler her seferinde yeniden oluşturulup sistem hafızasında tutulmaktadır. Modern grafik kartlarında, kartlara monte edilmiş hafıza kartları vardır ve veriler burada muhafaza edilmektedir. Bu sayede sistemde render edilen veriyi her seferinde ekran kartına gönderme zorunluluğu ortadan kalkmaktadır. Dolayısıyla bu işlem için ayrılan süre oldukça kısalmaktadır.
Direct3D VertexBuffer sınıfı ile köşeler hafızada tutulabilir. VertexBuffer sınıfı üç oluşturucuya sahiptir.

public VertexBuffer(Type typeVertexType, int numVerts, Device device, Usage usage, VertexFormats vertexFormat, Pool pool);

Burada, “typeVertexType” parametresi ile vertex türü, “numVerts” parametresi ile de kaç köşenin tamponda tutulacağı belirtilir. Bu sayı sıfırdan büyük olmalıdır.
“Microsoft.DirectX.Direct3D.Usage” isim alanındaki “usage” parametresi ile tamponun nasıl kullanılacağı belirtilir. Örnekteki “0” değeri Usage.None sıralı listesine karşılık gelmektedir. Diğer tiplere göz atacak olursak; 
Usage.Dynamic: Bu sayede AGP hafızasından da yararlanma şansına sahip olunacaktır.
AGP ile veri transferi daha hızlı olmaktadır(AGP pentium II türevli ana kartlarda kullanılmak için tasarlanmış olan bir sistemdir). Bu seçenek seçili değil ise köşeler ekran kartının hafızasından faydalanır.
Usage.Points:  Tampon(vertexbuffer) nokta çizimi için kullanılacaktır.
Usage. SoftwareProcessing: Köşe çizimleri yazılım tarafından yapılacaktır.
Usage.WriteOnly: Okuma işlemleri yapılmayacak, sadece yazma işlemleri yapılabilinecektir.
Pool.Default: Vertexbuffer, kart veya AGP hafızasında bulunabilir. Device nesnesi resetlendiği zaman otomatik olarak hafızadaki verilerde yok edilir.

__Mesh Kavramı__

Oyun programlamada veya simülasyonlarda, genellikle bir küp veya üçgen çizimi köşe tanımlanarak yapılmaz. Karmaşık şekillerin çizilmesi gerekiyorsa, veriler “.x” uzantılı dosyalarda tutulur.
DirectX’de Mesh nesnesi, verileri içerisinde tutabilmekte ve her türlü nesne bu sayede sahnede görüntülenebilmektedir. Tüm Mesh nesneleri vertexbuffer ve indexbuffer’a sahiptir. Ayrıca bazı parçalara hareket vermek de mümkündür. İlerleyen konularda bununla ilgili uygulamalar da yapacağız.
Mesh nesnelerini D3DX isim alanı içerisinde yer aldığı için;
“Microsoft.DirectX.Direct3DX.dll” referans olarak projemize eklemeliyiz.
Mesh önceden tanımlanmış köşe, doku ve material topluluğudur. “.X” dosyalarının, bu verileri içerisinde tuttuğunu daha önce söylemiştik. Peki, bu ne anlama geliyor? Örneğin, oyun programlayacağız ve bu oyun içerisinde uçaklar, tanklar ve arabalar yer alacak. Araba veya uçak nesneleri hazırlayıp, bunları ekranda görüntüleyeceğiz. Tahmin edeceğiniz gibi, tüm bu nesneleri oturup teker teker üçgen tanımlayarak yapmamız oldukça zor olacaktır. Bunun yerine 3DsMax veya Maya gibi tasarım programlarında hazırlanan tasarımları “.x” uzantılı dosya formatına dönüştürebiliriz. Tabii öncelikle modellerimizi tasarlayabilmek için bu konuda bilgi sahibi olmamız gerekmektedir. Eğer üç boyutlu modelleme konusunda fazla bir bilginiz yoksa o zaman “.x” uzantılı dosyaları internette bulabilir veya konu hakkında bilgi sahibi olan tasarımcı arkadaşlarınızdan yardım isteyebilirsiniz.



__DirectX  - Işık Kavramı__

DirectX’de ışık oldukça önemli bir kavramdır. Üç Boyutlu nesnelere renk ve gölge verebilmemizi sağlar. Nesnelere doku özelliği atanmamışsa ve sahnede ışık yoksa nesneler ekranda beyaz renkte görünür. Yukarıda bahsedilen uçak pervanesinin kendine ait bir rengi vardır. Bu renk bilgisi, nesnenin materyal bilgisi içerisinde tutulur. Ortama ışık eklediğimiz zaman bu rengi farkedebiliriz.
Direct3D’de dört tür ışık vardır: Bu ışık türleri; Directional, Point  Spot ve Ambient’dir. Işık türünü “Directional” olarak belirttiğimizde, ışıklar çok uzaktan geldiği için birbirine paralel olarak geldiği varsayılır. Ay ışığı ve güneş ışığını, bu ışık türüne örnek olarak gösterebiliriz. “Point” ışık türünde, ışık bir noktadan her yöne hareket eder. Bu ışık türüne, örnek olarak ampul gösterilebilir. 
“Spot” ışık türü, “Point” türüne benzer olup; her yönde değil sadece belirli bir yönde hareket söz konusudur.
“Ambient” ışık türünde ise ışık tüm nesnelere temas eder. Genel olarak ortam aydınlık görünür.
Diffuse: Sadece ışık kaynağının nesneye çarpması durumunda yansıma olur. 
Emissive: Yayılan ışığı temsil eder. Obje aydınlatılmasa bile nesne ışık yayabilir.
Specular: Metalik nesnelerin yaydığı renk ve yansıma olarak değerlendirilir.
Bir önceki örneğimizde, uçağın pervanesi ve tekerleklerine dikkat edersek, beyaz renkte olduklarını görürüz. “.x” uzantılı dosyayı DirectX görüntüleyicisiyle açtığımız zaman, bu nesnelerin orjinal renklerinin farklı olduklarını görürüz. Bunun sebebi ortamda ışığın olmamasıdır. Eğer ışık özelliklerini vermiş olsaydık orjinal renkleri de görüntüleme şansına sahip olurduk.
Bu örneğimizde koni, küre ve kutudan oluşan nesnemizin iki parçasına doku atadık. Üçüncü parçaya ise sadece renk özelliği atadık.
“device.RenderState.Lighting = false;”






__DirectX Matrisler__

DirectX’te matris fonksiyonlarını yer değiştirme, dönme ve boyutlandırma gibi işlemlerde kullanmaktayız. Bütün bu işlemler olmadan oyun veya simülasyon hazırlayamayız. Sahneye herhangi bir canlılık getiremeyiz. Konu hakkında fazla bir bilgiye sahip değilseniz internetten önbilgi edinmeniz faydalı olacaktır. Şimdi bazı kavramları daha yakından inceleyelim. Öncelikle niçin Matris kullanırız sorusunu cevaplamaya çalışalım.
Elimizde onbin köşeye sahip karışık bir nesnemiz var ve yüzü bize dönük  değil. Bu nesneyi ekranda düzgün bir şekilde görüntülememiz gerekiyor. Nesneyi önce Y ekseni yönünde çevirip, ardından boyutunu da biraz daha küçültürsek, ekranda normal bir şekilde görüntüleyebileceğiz. Bunu gerçekleştirebilmek için toplam altmış bin matematiksel işlem yapmamız gerekmektedir. Bu işlemleri teker teker yapmamızın olanağı yoktur. 
Tam bu noktada devreye matrisler girer ve bizim için oldukça zor olan bu hesaplamayı  kolaylıkla yapmamızı sağlar. Bu sebeple matrisleri kullanmamız oldukça önemlidir.

__Birim Matris__

Birim matrislerde [1,1],[2,2],[3,3][4,4] katsayıları hariç diğer tüm katsayılar “0” olarak kabul edilir. Birim matris köşelere uygulandığı zaman herhangi bir değişiklik gözlemlenmez. Dönme, boyutlandırma gibi köşe değerlerini değiştirme amaçlı kullanılırlar ve  4x4’lük matrisle ifade edilirler.
Genel olarak birim matrisleri, projelerimizde tanımladığımız matrislere başlangıç değerleri atamak için kullanacağız. Bu matris değerleri daha sonra nesnelerin dönme ve yer değiştirmelerine bağlı olarak değişecektir. 
__Görünüm Matrisi  (View Matrix)__
Görünüm matrisi kamerayı temsil etmektedir. Burada kameranın konum ve yönünü belirtiriz. Konum üç elemanlı bir vektörden oluşur ve dünya üzerindeki konum x, y, z cinsinden belirtilir. Bu vektöre “Eye Vector”’de denir. Yön ise iki vektör tarafından belirlenir (Look At Vector , Up Vector).
Bunlardan ilki “Look At Vector”, kameranın gösterdiği noktayı temsil etmektedir. Bu sayede görüş açısı belirlenebilmektedir. Diğer vektör ise genel olarak (0,1,0) değerini alır. Eğer (0,-1,0) olarak belirtilirse “y” değerine vermiş olduğumuz eksi(-) değer doğrultusunda kameranın baş aşağı durması sağlanmış olur.

__Projeksiyon  Matrisi (Projection Matrix)__

View Matrix kameramız ise, Projection Matrix kameranın lensini belirtir. 
“ZNear” parametresi ile kameraya olan uzaklık dünya koordinatları ile belirtilebilinir. Kameraya çok yakın olan nesneler çizilmezler. “ZFar” parametresi ile de kameradan çok uzak olan nesneler çizilmeyecektir.

__Dünya Matrisi (World Matrix)__

Köşeleri model uzayından dünya koordinatlarına dönüştürmek için kullanılır. Bu dönüşüm yer değiştirme, dönme ve boyutlarda değişiklik olarak belirtilebilir. Tüm bu dönüşümlerde farklı matrisler kullanılır ve daha sonra birleştirilirler. Matrisleri birleştirmek için, matrisler birbirleriyle çarpılır. Burada matrislerin çarpma sırası önemlidir; çünkü işlemlerin yapılma sıralaması, buna göre ayarlanmaktadır. Döndürme ve ardından yer değiştirme geliyorsa o zaman öncelikle nesne kendi ekseni etrafında dönecek, ardından da yer değiştirecektir. 
Yer Değiştirme Matrisi (Translation)
Yer değiştirme için matrisleri kullanarak kendi fonksiyonumuzu tanımlayabiliriz. 


Boyutlandırma (Scaling)
Nesnenin boyutlarını değiştirmek için kullanmaktayız.

```
Matrix boyutlandir(float B_x,float B_y,float B_z) {
Matrix ms = new Matrix();
ms.M11 = B_x;
ms.M12 = 0.0f;
ms.M13 = 0.0f;
ms.M14 = 0.0f;

ms.M21 = 0.0f;
ms.M22 = B_y;
ms.M23 = 0.0f;
ms.M24 = 0.0f;

ms.M31 = 0.0f;
ms.M32 = 0.0f;
ms.M33 = B_z;
ms.M34 = 0.0f;

ms.M41 = 0.0f;
ms.M42 = 0.0f;
ms.M43 = 0.0f;
ms.M44 = 1.0f;

return ms;
}
```
Veya bunun yerine aşağıdaki gibi de kullanabiliriz.
```
 Matrix boyutlandir(float B_x,float B_y,float B_z) {
       Matrix ms = Matrix.Identity;
        ms.M41 = x;
        ms.M42 = y;
        ms.M43 = z;
        ms.M44 = 1.0f;
    return ms;
}
```
Ayrıca yukarıdaki metotları kullanmak yerine DirectX’teki “Matrix.Scaling()” metodunu da kullanabiliriz.
Şimdiki örneğimizde tasarımını 3DsMax ile hazırlamış olduğumuz bir kulübeyi,  mouse ve klavye yardımıyla hem içeriden hem dışarıdan görüntüleyeceğiz. Tüm bu işlemlerde matrislerin ne kadar önemli olduğunu  bir kez daha vurgulamakta fayda var. Örnek için gereken dosyaları proje içerisine eklemeyi unutmayalım. 





__Dokular__

Çizilen nesnelerin ve uygulanan efektlerin sahne görüntülerinin gerçeğe yakın olması gerekir. Sahnede bu gerçekliğin kolayca elde edilebilmesinde en büyük pay dokulara aittir. Basit örneklerle konuyu açıklamaya çalışalım. Sahnenin uzak bir yerine buzdolabı yerleştireceğiz. Buzdolabı modelini sahnede kullanmak yerine, sahneye dörtgen bir prizma veya bir düzlem çizerek, görünen yüzey üzerine bir buzdolabı dokusu atayabiliriz. Bu sayede kolaylıkla istediğimiz görüntüyü elde ederiz.
Mesela araba ile şehir içerisinde gezintiye çıkarken, binaların önünden geçeceğiz. Bunun için yapmamız gereken, çizilen bir düzlem üzerine bina resimlerinin bulunduğu dokuları atamak olacaktır. Bazı dokuları arka arkaya göstermek suretiyle farklı efektler  de elde edebiliriz. Konuyla ilgili örnekler çoğaltılabilir.
Sonuç olarak, dokular sahnelerimizin vazgeçilmez unsurlarıdır. 






__DirectSound ile Sahneye Ses Eklenmesi__

Oyunlarda ses efektinin ne kadar önemli olduğunu hepimiz biliriz. Modeller, nesne hareketleri ve efektler ne kadar gerçekçi olursa olsun, oyunu bir bütün olarak ele aldığımızda, sesin ne derece önemli olduğu ortadadır. Oyun içerisindeki ses efektleri oyuna daha iyi konsantre olmamızı sağlar.
DirectX’te “DirectSound” isimalanında yeralan “Device” sınıfını sahnelerimize ses eklemek için kullanmaktayız. Burada Device sınıfının nesnesi oluşturularak, donanımla iletişime geçmek mümkün olmaktadır. Birden fazla uygulama Device nesnesini kullanabilir. Uygulamalarda Birincil-tampon (PrimaryBuffer) ses kartı tarafından hazırlanırken, İkincil-tampon (SecondaryBuffer) uygulamalar tarafından hazırlanır. Birincil ve ikincil tampondaki veri daha sonra birleştirilerek dışarı aktarılır ve bizler bu sesleri duyarız. Uygulamalar ikincil tamponu kullanırlar.
Device nesnesi ve PrimaryBuffer özelliği uygulama içinde en fazla bir kere tanımlanabilir. SecondaryBuffer nesnesi ise her ayrı ses için tanımlanabilir. Ses efektleri ise oluşturulan  SecondaryBuffer nesnesine istenilen miktarda uygulanabilir. 




__DirectSound Pan, Volume, Frequency Özellikleri__

Ses üzerinde daha fazla hakimiyet kurabilmemiz için DirectSound isimalanındaki Buffer sınıfı nesnesinden yararlanmamız gerekmektedir. Bu nesne sayesinde, ses yüksekliğinin hoparlörlere hangi oranda dağıtıldığını (sağ-sol) belirleyebilmekteyiz. Bunun yanı sıra ses frekansı ile ilgili özelliklere de müdahale edebilmekteyiz.
Pan, Volume, Frequency özellikleri tamsayı değerler almaktadır. Bu sebeple kullanımı da oldukça kolaydır.
Örneğin:
```
d3ses.Buffer buf;
buf.Volume = 100;
```
DirectSound isimalanında sesi daha fazla arttırmak oldukça zordur. Bu sebeple ses dosyalarını kaydederken mümkün olduğunca yüksek sesle kaydetmeliyiz. Sesi tamamen kısmak istersek değeri  -10,000’e getirmemiz gerekmektedir. 
Frekans özelliğini “0” değerine getirirsek sesi orjinal haline getirmiş oluruz.
Pan özelliği ise sesin sağ ve sol konumunu kontrol etmektedir. Değer “0”  ise sağ ve sol hoparlörlere ses  eşit miktarda ve maksimum yükseklikte dağıtılmaktadır. Değerler          -10000 ve +10000  arası değişiklik göstermektedir. +10000 değerinde ses sağ hoparlöre, maksimum yükseklikte ulaşacaktır.
Frekans değeri, saniyede çalmasını istediğimiz, tamponda tutulan veri miktarıdır. Bu değer 1- 100.000 arasında olabilmektedir. Gelişmiş bazı sistemlerde değer daha da yukarı çıkabilmektedir.
Frekansı değiştirdikten sonra, örneğin  “buf.Frequency = 50000;” değerini verdikten sonra bu değeri tekrar normal değerine  dönüştürmek için yapılması gereken:
“buf.Frequency = buf.Format.SamplesPerSecond;” komutunu uygulamaya eklemektir.
