# -directxmanaged

### Kodları Çalıştırmak
Gerekli olan kurulum dosyalarını GoogleDrive’da bulabilirsiniz. Takip ediyorsanız Managed DirectX teknolojisi ve bununla birlikte XNA teknolojileri artık kullanılmamaktadır. Yazılan kitap 2008 yılındaki zamanın  güncel teknolojilerine göre yazılmıştır. Bunun yerine daha hızlı ve lightweight ortamlar kullanılmaktadır. Gdevelop, Unity gibi. Güncel teknolojilerin takip edilmesi gerekmektedir. 

Uygulamalarımızın çalışabilmesi için, bilgisayarınızda Microsoft Visual Studio 2005, .Net Framework 2.0 ve örnek uygulamaları inceleyebilmek için de DirectX SDK’nın (August-2006) yüklü olması gerekir. Vmware workstation kullanarak uygulamaları ayağa kaldırabilirsiniz.



<p align="center">
  <img  src="https://github.com/okansungur/portfolio/blob/main/gpimages/vpc1.png" width=100% height=100% ><br/>
   Game Programming 2008
</p>


Microsoft DirectX İsimalanları
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


3D-Koordinat Sistemleri
OpenGL, sağ ele dayanan koordinat sistemi kullanırken, Direct3D sol ele dayanan bir koordinat sistemi kullanır. Her iki sistemde de +X sağa, –X ise sola doğru gider.
Sağ el ve sol el koordinat sistemleri arasındaki farka gelince; sağ eli kullanan koordinat sisteminde +Z ekrandan dışarı doğru gelirken, sol ele dayanan koordinat sisteminde +Z ekrandan uzaklaşır.
Örneğin; (9,-2,7) noktası için sol ele dayanan koordinat sistemi kullanıldığında; tanımlanan değer, 9 birim sağa 2 birim alta, 7 birim ekrana doğru olan noktayı temsil eder. Bir sonraki örneğimizde koordinat sistemlerini daha yakından inceleyeceğiz.

Sağ ele dayanan koordinat sisteminde sağ elimizin başparmağı X eksenini, diğer parmaklar ise Y eksenini gösterecek şekilde tutulduğunda, “Z ekseni” avuç içi yönünde ekrandan dışarıya doğru yönlenmektedir. Sol ele dayanan koordinat sisteminde ise yine başparmak X ekseni yönünde, diğer parmaklar y ekseni yönünde tutulduğunda avuç içi Z eksenini göstermekte yani ekrandan içeriye doğru yönlenmektedir. Direct3D sol-ele dayanan koordinat sistemini kullanmaktadır.

Kamera Tanımlanması
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


Sahneye İlk Işığı Ekleme
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
Mesh Kavramı
Oyun programlamada veya simülasyonlarda, genellikle bir küp veya üçgen çizimi köşe tanımlanarak yapılmaz. Karmaşık şekillerin çizilmesi gerekiyorsa, veriler “.x” uzantılı dosyalarda tutulur.
DirectX’de Mesh nesnesi, verileri içerisinde tutabilmekte ve her türlü nesne bu sayede sahnede görüntülenebilmektedir. Tüm Mesh nesneleri vertexbuffer ve indexbuffer’a sahiptir. Ayrıca bazı parçalara hareket vermek de mümkündür. İlerleyen konularda bununla ilgili uygulamalar da yapacağız.
Mesh nesnelerini D3DX isim alanı içerisinde yer aldığı için;
“Microsoft.DirectX.Direct3DX.dll” referans olarak projemize eklemeliyiz.
Mesh önceden tanımlanmış köşe, doku ve material topluluğudur. “.X” dosyalarının, bu verileri içerisinde tuttuğunu daha önce söylemiştik. Peki, bu ne anlama geliyor? Örneğin, oyun programlayacağız ve bu oyun içerisinde uçaklar, tanklar ve arabalar yer alacak. Araba veya uçak nesneleri hazırlayıp, bunları ekranda görüntüleyeceğiz. Tahmin edeceğiniz gibi, tüm bu nesneleri oturup teker teker üçgen tanımlayarak yapmamız oldukça zor olacaktır. Bunun yerine 3DsMax veya Maya gibi tasarım programlarında hazırlanan tasarımları “.x” uzantılı dosya formatına dönüştürebiliriz. Tabii öncelikle modellerimizi tasarlayabilmek için bu konuda bilgi sahibi olmamız gerekmektedir. Eğer üç boyutlu modelleme konusunda fazla bir bilginiz yoksa o zaman “.x” uzantılı dosyaları internette bulabilir veya konu hakkında bilgi sahibi olan tasarımcı arkadaşlarınızdan yardım isteyebilirsiniz.


