document.addEventListener('DOMContentLoaded', () => {
    // Popüler ürünler ve kategoriler için veri örnekleri
    const popularProducts = [
        { name: 'Aspirin', description: 'Ağrı kesici', price: '10 TL' },
        { name: 'Parol', description: 'Ateş düşürücü', price: '8 TL' },
        { name: 'Nurofen', description: 'Ağrı kesici', price: '12 TL' },
    ];

    const categories = [
        'Ağrı Kesici', 'Ateş Düşürücü', 'Vitaminler', 'Cilt Bakımı'
    ];

    // Anasayfa için ürün ve kategori kartları oluşturma
    if (document.querySelector('.product-list')) {
        const productContainer = document.querySelector('.product-list');
        popularProducts.forEach(product => {
            const productCard = document.createElement('div');
            productCard.classList.add('card');
            productCard.innerHTML = `
                <h3>${product.name}</h3>
                <p>${product.description}</p>
                <p>${product.price}</p>
            `;
            productContainer.appendChild(productCard);
        });
    }

    if (document.querySelector('.category-list')) {
        const categoryContainer = document.querySelector('.category-list');
        categories.forEach(category => {
            const categoryCard = document.createElement('div');
            categoryCard.classList.add('card');
            categoryCard.innerHTML = `<h3>${category}</h3>`;
            categoryContainer.appendChild(categoryCard);
        });
    }
});
