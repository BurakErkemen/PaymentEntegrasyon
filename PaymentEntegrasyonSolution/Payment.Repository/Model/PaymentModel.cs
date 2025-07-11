﻿using Google.Cloud.Firestore;

namespace Payment.Repository.Model
{
    [FirestoreData]
    public class PaymentModel
    {
        [FirestoreProperty("UserId")]
        public string UserId { get; set; } = default!;

        [FirestoreProperty("paymentId")]
        public string PaymentId { get; set; } = default!;

        [FirestoreProperty("BuyerName")]
        public string BuyerName { get; set; } = default!;

        [FirestoreProperty("Price")]
        public double Price { get; set; }

        [FirestoreProperty("CreatedAt")]
        public Timestamp CreatedAt { get; set; }
    }
}
