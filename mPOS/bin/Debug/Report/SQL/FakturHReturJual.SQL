SELECT HReturJual.Bayar, HReturJual.Sisa, HSatuan.Kode AS Satuan, HBarang.Kode AS KDBarang, HBarang.Nama AS NmBarang, HReturJualD.*, HReturJual.Kode, HReturJual.Tanggal, HReturJual.TglTempo, HReturJual.Total, HReturJual.Reff, HKontak.Kode AS KDCustomer, HKontak.Nama AS NamaCustomer, HKontak.Alamat 
FROM HReturJual
INNER JOIN HReturJualD ON HReturJual.NoID=HReturJualD.IDHeader 
LEFT JOIN HBarang ON HBarang.NoID=HReturJualD.IDBarang
LEFT JOIN HSatuan ON HSatuan.NoID=HReturJualD.IDSatuan
LEFT JOIN HKontak ON HKontak.NoID=HReturJual.IDCustomer