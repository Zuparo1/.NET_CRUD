<script>
    import { onMount } from 'svelte';
</script>

<nav>
    <a href="/">Home</a>
    <a href="/bookList">Books</a>
    <a href="/addBooks">Add Book</a>
</nav>

<slot />

<style>
    :global(body) {
        font-family: 'Helvetica Neue', Arial, sans-serif;
        margin: 0;
        padding: 0;
        background-color: #f4f4f9;
        color: #333;
    }

    nav {
        background-color: #007BFF;
        padding: 1rem;
        text-align: center;
    }

    nav a {
        margin: 0 1rem;
        text-decoration: none;
        color: white;
        font-weight: bold;
    }

    nav a:hover {
        text-decoration: underline;
    }

    main {
        max-width: 800px;
        margin: 2rem auto;
        padding: 2rem;
        background: white;
        border-radius: 8px;
        box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    }

    h1, h2 {
        color: #007BFF;
    }
</style>