window.addEventListener('DOMContentLoaded', () =>{
    const script = document.createElement('script');

    script.type = 'module';
    script.innerHTML = `
        import mermaid from 'https://cdn.jsdelivr.net/npm/mermaid@11.8.0/dist/mermaid.esm.min.mjs';
        mermaid.initialize({ startOnLoad: true });
    `
});
