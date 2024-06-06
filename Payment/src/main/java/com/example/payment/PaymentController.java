package com.example.payment;

import org.apache.catalina.User;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/theatres")
public class PaymentController {
    @GetMapping
    public String getPayment() {
        return "Hello, World!";
    }
    @PostMapping
    public String setPayment() {
        return "Hello, World!";
    }
    @DeleteMapping String deletePayement(){return "Hello, World!";}
    @PutMapping String updatePayment(){return "Hello, World!";}
}
