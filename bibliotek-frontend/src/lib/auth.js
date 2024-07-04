
export token = writable('');

async function login(username, password) {
    const res = await fetch(`https://localhost:32782/api/auth/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password })
    )

    if (res.ok) {
        const data = await res.json();
        token.set(data.token);
        return data.token;
    } else {
        throw new Error('Invalid username or password');
    }
}