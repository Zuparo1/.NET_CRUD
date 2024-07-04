import { writable } from 'svelte/store';

export const books = writable([]);

export const api = "https://localhost:32786/api/bok";

export const loadBooks = async () => {
    const res = await fetch(api)
    const data = await res.json();
    books.set(data);
};

export const createBook = async (bok) => {
    const res = await fetch(api, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(bok)
    });
    await res.json();
    loadBooks();
};

export const updateBook = async (id, bok) => {
    const res = await fetch(`${api}/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(bok)
    });
    await res.json();
    loadBooks();
};

export const deleteBook = async (id) => {
    await fetch(`${api}/${id}`, {
        method: "DELETE"
    });
    loadBooks();
};