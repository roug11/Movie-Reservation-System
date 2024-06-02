package com.example.theatre;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class TheatreController {
    @GetMapping
    public String sayHello() {
        return "Hello, World!";
    }
}
