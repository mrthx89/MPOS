SELECT HSatuan.Kode AS Satuan, HBarang.Kode AS KDBarang, HBarang.Nama AS NmBarang, HBeliD.*, HBeli.Kode, HBeli.Tanggal, HBeli.TglTempo, HBeli.Total, HBeli.Reff, HKontak.Kode AS KDSupplier, HKontak.Nama AS NamaSupplier, HKontak.Alamat 
FROM HBeli 
INNER JOIN HBeliD ON HBeli.NoID=HBeliD.IDHeader 
LEFT JOIN HBarang ON HBarang.NoID=HBeliD.IDBarang
LEFT JOIN HSatuan ON HSatuan.NoID=HBeliD.IDSatuan
LEFT JOIN HKontak ON HKontak.NoID=HBeli.IDSupplier 