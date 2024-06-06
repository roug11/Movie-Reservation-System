package com.example.theatre;

import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/theatres")
public class TheatreController {
    @GetMapping
    public String getTheatre() {
        return "Hello, World!";
    }
    @PostMapping
    public String setTheatre() {
        return "Hello, World!";
    }
    @DeleteMapping
    String deleteTheatre(){return "Hello, World!";}
    @PutMapping String updateTheatre(){return "Hello, World!";}
}
