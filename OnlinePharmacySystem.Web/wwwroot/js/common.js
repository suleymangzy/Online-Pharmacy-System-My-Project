document.addEventListener('DOMContentLoaded', () => {
    // Ortak JavaScript işlevsellikleri burada tanımlanabilir
    console.log('Ortak JavaScript dosyası yüklendi.');

    // Örnek bir işlev: sayfanın en üstüne dönme düğmesi
    const scrollToTopButton = document.createElement('button');
    scrollToTopButton.textContent = 'Yukarı Dön';
    scrollToTopButton.style.position = 'fixed';
    scrollToTopButton.style.bottom = '20px';
    scrollToTopButton.style.right = '20px';
    scrollToTopButton.style.padding = '10px';
    scrollToTopButton.style.backgroundColor = '#4CAF50';
    scrollToTopButton.style.color = 'white';
    scrollToTopButton.style.border = 'none';
    scrollToTopButton.style.cursor = 'pointer';
    scrollToTopButton.style.display = 'none';

    document.body.appendChild(scrollToTopButton);

    window.addEventListener('scroll', () => {
        if (window.scrollY > 300) {
            scrollToTopButton.style.display = 'block';
        } else {
            scrollToTopButton.style.display = 'none';
        }
    });

    scrollToTopButton.addEventListener('click', () => {
        window.scrollTo({ top: 0, behavior: 'smooth' });
    });
});
